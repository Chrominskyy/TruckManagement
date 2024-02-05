
# TruckManagement.API

## Version: v1

### Endpoints

---

### /v1/trucks

#### GET
##### Summary
Gets a list of trucks registered in the system.

##### Responses
| Code | Description |
| ---- | ----------- |
| 200  | A JSON array of trucks. Each element in the array is a truck object containing truck details. |

#### POST
##### Summary
Adds a new truck to the system. Requires a truck object in the request body.

##### Request Body
- `application/json`

```json
{
  "code": "ABC123",
  "name": "ABC Truck",
  "description": "ABC Truck is used only to transport livestock. DO NOT TRANSPORT hay with it",
  "status": 0
}
```

##### Responses
| Code | Description |
| ---- | ----------- |
| 200  | Truck added successfully. Returns the added truck object. |
| 400  | Bad request. The request body is missing or contains invalid data. |

#### PUT
##### Summary
Updates an existing truck in the system. Requires a truck object in the request body.

##### Request Body
- `application/json`

```json
{
  "code": "ABC123",
  "name": "ABC Truck Updated",
  "description": "ABC Truck is used only to transport livestock. DO NOT TRANSPORT hay with it",
  "status": 1
}
```

##### Responses
| Code | Description |
| ---- | ----------- |
| 200  | Truck updated successfully. Returns the updated truck object. |
| 400  | Bad request. The request body is missing or contains invalid data. |

---

### /v1/trucks/{code}

#### GET
##### Summary
Gets a truck by its unique code.

##### Parameters
| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ------ |
| code | path | The unique code of the truck to retrieve. | Yes | string |

##### Responses
| Code | Description |
| ---- | ----------- |
| 200  | Success. Returns a single truck object. |

#### DELETE
##### Summary
Removes a truck from the system by its unique code.

##### Parameters
| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ------ |
| code | path | The unique code of the truck to remove. | Yes | string |

##### Responses
| Code | Description |
| ---- | ----------- |
| 204  | No Content. The truck was successfully removed from the system. |

---

### /v1/trucks/search

#### GET
##### Summary
Gets a list of trucks filtered and sorted based on parameters.

##### Parameters
| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ------ |
| code | query | Filter by truck code, e.g., "ABC123". | No | string |
| name | query | Filter by truck name, e.g., "Truck Name 123". | No | string |
| status | query | Filter by truck status, using the `StatusEnum` values. | No | [StatusEnum](https://github.com/Chrominskyy/TruckManagement/blob/init/TruckManagement.Domain/Enums/StatusEnum.cs) |
| sortColumn | query | Specify the column to sort by, e.g., "Name". | No | string |
| sortDirection | query | Specify the sort direction, "ASC" or "DESC". | No | string |

##### Responses
| Code | Description |
| ---- | ----------- |
| 200  | Success. Returns a filtered and sorted list of trucks. |
