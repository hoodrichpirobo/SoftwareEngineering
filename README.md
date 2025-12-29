# ManteHos Logic Layer — Services & Domain Classes

This README is a **deep, human‑friendly, end‑to‑end description of the Logic Layer** used in the ManteHos project. It focuses on **services** and **domain classes**, explains **responsibilities**, **data relationships**, and **business rules**, and points you directly to the relevant source files so you can verify every statement in code.

> **Scope**: The logic layer is implemented in `ManteHosLib/BusinessLogic` and relies on domain entities defined as `partial` classes across both `BusinessLogic/Entities` (constructors/behavior) and `Persistence/Entities` (properties/relationships). The service layer lives in `BusinessLogic/Services` and depends on the `IDAL` abstraction in `Persistence/EntityFrameWorkImp/IDAL.cs`.

---

## 1. High‑Level Architecture (Logic Layer Focus)

**Layers & responsibilities** (from the perspective of logic code):

- **Logic/Business Layer** (`ManteHosLib/BusinessLogic`)
  - Implements *application use‑cases* (login, reporting incidents, accepting/rejecting incidents, work order lifecycle).
  - Provides *domain behavior* (constructors, invariants, helper methods).
  - Enforces *business rules* and *role permissions*.

- **Persistence Layer** (`ManteHosLib/Persistence`)
  - Stores and retrieves entities via the `IDAL` interface.
  - Supplies `partial` entity definitions (properties, EF mappings) used by the logic layer.

**Key idea:**
- The logic layer orchestrates workflows, validates role permissions, and modifies domain objects.
- Persistence details are hidden behind `IDAL` so business logic remains database‑agnostic.

---

## 2. Service Layer: `ManteHosService`

**Source:** `ManteHosLib/BusinessLogic/Services/ManteHosService.cs`  
**Interface:** `ManteHosLib/BusinessLogic/Services/IManteHosService.cs`  
**Exception type:** `ManteHosLib/BusinessLogic/Services/ServiceException.cs`

### 2.1. Service Overview
`ManteHosService` is the central application service that:

- Maintains the **current logged‑in user** (`Employee Logged`).
- Implements **core use‑cases** (login, incident reporting, acceptance, rejection, work order assignment, work order closing).
- Enforces **role‑based permissions** and **data constraints**.
- Commits changes through the **IDAL** abstraction.

### 2.2. Dependencies

- **`IDAL`** (`ManteHosLib/Persistence/EntityFrameWorkImp/IDAL.cs`)
  - Provides generic CRUD, queries, and transaction control.
- **Domain Entities** (`ManteHos.Entities` namespace)
  - `Employee`, `Head`, `Master`, `Operator`, `Incident`, `Area`, `WorkOrder`, `Part`, `UsedPart`.
- **Enums**
  - `Priority`, `Status`, `Shift`.

### 2.3. Service Methods & Business Rules

Below is a **method‑by‑method** summary of the service behavior and constraints.

#### Initialization & Persistence
- **`RemoveAllData()`**
  - Clears database content via `dal.RemoveAllData()`.
- **`Commit()`**
  - Persists pending changes via `dal.Commit()`.
- **`DBInitialization()`**
  - Resets the database, then seeds initial users, areas, and parts.
  - Creates:
    - `Head`, `Master`, `Operator`, `Employee` instances.
    - `Area` objects tied to `Master`.
    - `Part` objects with stock details.

#### User Session Handling
- **`LogIn(username, password)`**
  - Validates user existence with `dal.GetById<Employee>(username)`.
  - Checks password match.
  - Stores logged user in `Logged`.
  - **Errors:** throws `ServiceException` if user does not exist or password is wrong.

- **`LogOut()`**
  - Clears session by setting `Logged = null`.

- **`GetLoggedUser()`**
  - Returns the current `Employee` (can be `null`).

- **`IsLogged()` / `GetUser()`**
  - Utility helpers for UI/flow logic.

#### Incident Reporting (Employee)
- **`ReportIncident(date, department, description)`**
  - Requires a logged‑in user.
  - Creates a new `Incident` tied to the logged `Employee`.
  - **Errors:** throws if no user is logged in.

#### Incident Review (Head)
- **`GetIncidentsPendingAcceptance()`**
  - **Role‑restricted:** only a logged‑in `Head`.
  - Returns incidents with `Status.Created`.

- **`AcceptIncident(incidentId, areaName, priority)`**
  - **Role‑restricted:** only `Head`.
  - Validates incident and area existence.
  - Updates incident `Area`, `Priority`, and `Status = Accepted`.
  - Commits changes.

- **`RejectIncident(incidentId, reason)`**
  - **Role‑restricted:** only `Head`.
  - Sets `Status = Rejected` and records `RejectionReason`.
  - Commits changes.

#### Work Order Assignment (Master)
- **`GetPendingIncidentsForLoggedMaster()`**
  - **Role‑restricted:** only logged `Master`.
  - Requires `Master.Area` assigned.
  - Returns incidents in that area where status is not `Rejected` or `Completed`.

- **`GetWorkOrderRelatedToIncident(incident)`**
  - Looks up existing `WorkOrder` for the given `Incident`.
  - Returns `null` if none exists.

- **`CreateWorkOrder(incident)`**
  - Prevents duplicate work orders for the same incident.
  - Creates new `WorkOrder` with `StartDate = now` and reference to `Incident`.
  - Commits and returns the created work order.

- **`GetAvailableOperatorsForWorkOrder(workOrder)`**
  - Returns operators not already assigned to the given work order.

- **`AddOperatortoWorkOrder(workOrder, operatorId)`**
  - Finds operator by ID.
  - Prevents duplicates.
  - Adds operator and commits.

- **`RemoveOperatorFromWorkOrder(workOrder, operatorId)`**
  - Removes operator if assigned.
  - Throws if not assigned.

#### Work Order Closing (Operator)
- **`GetOpenWorkOrdersForLoggedOperator()`**
  - **Role‑restricted:** only logged `Operator`.
  - Returns work orders with `EndDate == null` assigned to that operator.

- **`CloseWorkOrder(workOrderId, repairReport, endDate = null)`**
  - **Role‑restricted:** only logged `Operator`.
  - Validations:
    - Work order must exist.
    - Work order must be open.
    - Operator must be assigned to that work order.
    - No pending parts (`UsedPart.Needed == true`).
  - Updates:
    - `WorkOrder.RepairReport` and `WorkOrder.EndDate`.
    - `Incident.Status = Completed`.
    - `Incident.CostOfUsedParts` is computed from used parts.
  - Commits changes.

### 2.4. Error Handling

- **`ServiceException`** is thrown for all domain‑level violations (e.g., wrong role, missing entities, invalid state).
- UI or controller layers should catch `ServiceException` to display clear messages to users.

---

## 3. Domain Entities (Classes in the Logic Layer)

All entities live in the `ManteHos.Entities` namespace and are defined as **partial classes**, split between:

- **`BusinessLogic/Entities`** → constructors, behavior, invariants.
- **`Persistence/Entities`** → properties, EF mapping, relationships.

Below is a **clean conceptual map** of each domain class, its purpose, and relationships.

### 3.1. People & Roles

#### `Employee`
**Files:**
- `BusinessLogic/Entities/Employee.cs`
- `Persistence/Entities/Employee.cs`

**Purpose:** Base class for all human actors in the system.

**Key properties:**
- `Id` (string) — primary identifier (used for login).
- `FullName` (string) — display name.
- `Password` (string) — login credential.
- `ReportedIncidents` (collection) — incidents submitted by this employee.

**Behavior:**
- Constructor initializes `ReportedIncidents` collection.

#### `Head` (inherits `Employee`)
**Files:**
- `BusinessLogic/Entities/Head.cs`
- `Persistence/Entities/Head.cs`

**Purpose:** Supervisor role, responsible for accepting/rejecting incidents.

**Behavior:**
- Constructor only delegates to `Employee`.

#### `Master` (inherits `Employee`)
**Files:**
- `BusinessLogic/Entities/Master.cs`
- `Persistence/Entities/Master.cs`

**Purpose:** Area lead who assigns and manages work orders.

**Key properties:**
- `Area` — the area they manage.

#### `Operator` (inherits `Employee`)
**Files:**
- `BusinessLogic/Entities/Operator.cs`
- `Persistence/Entities/Operator.cs`

**Purpose:** Executes work orders.

**Key properties:**
- `Shift` (`Shift` enum) — morning/afternoon/night.
- `WorkOrders` — work orders assigned to the operator.

**Behavior:**
- Constructors initialize `WorkOrders` and set shift.

---

### 3.2. Operational Entities

#### `Area`
**Files:**
- `BusinessLogic/Entities/Area.cs`
- `Persistence/Entities/Area.cs`

**Purpose:** Organizational unit that groups incidents and is led by a `Master`.

**Key properties:**
- `Name` — area name (unique per business rule).
- `Master` — leader responsible for the area.
- `Incidents` — incidents assigned to this area.

**Behavior:**
- Constructor initializes `Incidents` collection.

#### `Incident`
**Files:**
- `BusinessLogic/Entities/Incident.cs`
- `Persistence/Entities/Incident.cs`

**Purpose:** A reported issue or failure that requires maintenance.

**Key properties:**
- `Id` — unique identifier.
- `ReportDate` — when it was reported.
- `Department` — department that reported it.
- `Description` — incident details.
- `Priority` (`Priority` enum) — default `Low`.
- `Status` (`Status` enum) — default `Created`.
- `RejectionReason` — free‑text if rejected.
- `CostOfUsedParts` — computed total from work order parts.
- `Area` — assigned maintenance area.
- `Reporter` — `Employee` who reported it (required).
- `WorkOrder` — work order linked to the incident.

**Behavior:**
- Constructor sets department, description, report date, and reporter.

#### `WorkOrder`
**Files:**
- `BusinessLogic/Entities/WorkOrder.cs`
- `Persistence/Entities/WorkOrder.cs`

**Purpose:** The unit of execution that resolves an incident.

**Key properties:**
- `Id` — unique identifier.
- `StartDate` — when work starts.
- `EndDate` — when work is closed (nullable).
- `RepairReport` — summary of the performed repair.
- `Incident` — required incident reference (1‑to‑1).
- `Operators` — assigned operators.
- `UsedParts` — parts consumed by the work.

**Behavior:**
- Constructor initializes operators and used parts collections.
- `AddUsedPart(quantity, part)`
  - Creates a `UsedPart`, updates inventory or marks `Needed`.
- `AddOperator(op)`
  - Adds operator if not already assigned.

#### `Part`
**Files:**
- `BusinessLogic/Entities/Part.cs`
- `Persistence/Entities/Part.cs`

**Purpose:** Inventory item used in repairs.

**Key properties:**
- `Code` — unique part code (primary key).
- `Description` — human‑readable description.
- `UnitPrice` — cost per unit.
- `CurrentQuantity` — stock on hand.
- `MinimunQuantity` — minimum allowable stock.
- `UnitOfMeasure` — unit (e.g., pieces, meters).
- `UsedParts` — references in work orders.

**Behavior:**
- Constructor initializes `UsedParts` and sets core fields.

#### `UsedPart`
**Files:**
- `BusinessLogic/Entities/UsedPart.cs`
- `Persistence/Entities/UsedPart.cs`

**Purpose:** Association entity that tracks how many parts are used by a work order.

**Key properties:**
- `Id` — unique identifier.
- `Quantity` — amount used.
- `Needed` — true if inventory drops below minimum.
- `Part` — the referenced part (required).

**Behavior:**
- Constructor checks stock levels:
  - If stock would drop below minimum, marks `Needed = true`.
  - Otherwise, reduces `Part.CurrentQuantity`.

---

### 3.3. Enumerations

- **`Shift`**: `Morning`, `Afternoon`, `Night`
- **`Priority`**: `High`, `Medium`, `Low`
- **`Status`**: `Created`, `Accepted`, `Rejected`, `InProgress`, `Pending`, `Completed`

These enums define states and classification used throughout the logic layer.

---

## 4. End‑to‑End Use‑Case Flows (Logic Layer Perspective)

### Flow A — Reporting an Incident
1. `Employee` logs in (`LogIn`).
2. Calls `ReportIncident(...)`.
3. System creates `Incident` with:
   - `Status = Created`
   - `Priority = Low` by default

### Flow B — Review & Acceptance (Head)
1. `Head` logs in.
2. `GetIncidentsPendingAcceptance()` returns all `Created` incidents.
3. `AcceptIncident(id, area, priority)` sets:
   - `Area`, `Priority`, `Status = Accepted`
4. If rejected, `RejectIncident(id, reason)` sets:
   - `Status = Rejected`, `RejectionReason`.

### Flow C — Work Order Assignment (Master)
1. `Master` logs in and has an `Area`.
2. `GetPendingIncidentsForLoggedMaster()` returns area incidents.
3. `CreateWorkOrder(incident)` creates a new `WorkOrder`.
4. Operators are assigned via `AddOperatortoWorkOrder`.

### Flow D — Work Order Execution & Close (Operator)
1. `Operator` logs in.
2. `GetOpenWorkOrdersForLoggedOperator()` lists active orders.
3. Operator performs work, uses parts.
4. `CloseWorkOrder(...)` validates that:
   - Parts needed are resolved.
   - Operator is assigned.
5. Incident status changes to `Completed` and cost is computed.

---

## 5. Business Rules Enforced by the Logic Layer

**Identity & uniqueness**
- No duplicate `Employee.Id`.
- No duplicate `Area.Name`.
- No duplicate `Part.Description`.

**Role‑based actions**
- Only `Head` can accept or reject incidents.
- Only `Master` can assign work orders.
- Only `Operator` can close work orders.

**Work order lifecycle**
- A work order cannot be closed if:
  - It is already closed.
  - The operator is not assigned to it.
  - There are pending parts (`UsedPart.Needed == true`).

**Inventory impact**
- Using a part updates `Part.CurrentQuantity`, or sets `UsedPart.Needed` if below minimum.

---

## 6. Where to Find the Logic Layer Code

| Concern | Path | Key Types |
|---|---|---|
| Service layer | `ManteHosLib/BusinessLogic/Services` | `ManteHosService`, `IManteHosService`, `ServiceException` |
| Domain behaviors | `ManteHosLib/BusinessLogic/Entities` | Constructors & helper methods |
| Entity properties & relationships | `ManteHosLib/Persistence/Entities` | Entity fields, EF annotations |
| Persistence abstraction | `ManteHosLib/Persistence/EntityFrameWorkImp/IDAL.cs` | `IDAL` interface |

---

## 7. Quick Glossary

- **DAL**: Data Access Layer, abstracted by `IDAL`.
- **Incident**: A reported maintenance issue.
- **Work Order**: A unit of work that resolves an incident.
- **Used Part**: A record of parts consumed in a work order.
- **Master**: Area manager who assigns work orders.
- **Head**: Reviewer who accepts/rejects incidents.
- **Operator**: Technician who executes and closes work orders.

---

## 8. Why This Logic Layer Is Cohesive

The logic layer is intentionally **simple, explicit, and clear**:

- **Service methods map directly to course use‑cases**, which makes the system easy to read and verify.
- **Entity constructors guarantee valid default state**, and **service methods enforce permissions**.
- The **IDAL abstraction keeps business logic clean**, enabling reuse with any persistence technology.

---

If you want an even deeper walkthrough (class diagrams, state charts, or API sequences), feel free to ask—this README is designed as a solid foundation for any further documentation.
