##  Add & Delete Teachers (Part 2)

### Web Pages:
- `/TeacherPage/New` – Add new teacher form
- `/TeacherPage/DeleteConfirm/{id}` – Delete confirmation

### API:
- `POST /api/TeacherAPI` – Add teacher via JSON
- `DELETE /api/TeacherAPI/{id}` – Delete teacher by ID

Example cURL:
```bash
curl -X POST https://localhost:xxxx/api/TeacherAPI -H "Content-Type: application/json" -d "{\"FirstName\":\"Sara\",\"LastName\":\"Lee\",\"HireDate\":\"2021-01-01\"}"
curl -X DELETE https://localhost:xxxx/api/TeacherAPI/3
