# cURL commands for integration testing

## Register a project
curl --location --request POST 'http://localhost:3001/api/projects/register' \
--header 'Content-Type: application/json' \
--data-raw '{
    "name": "e-conomic TimeLogger 5",
    "deadline": "2021-03-21T00:00:00",
    "weeks": []
}'

## Register a week under a project
curl --location --request POST 'http://localhost:3001/api/week/register' \
--header 'Content-Type: application/json' \
--data-raw '{
    "projectId": 1,
    "weekNr": 2,
    "days": [
        {
            "weekId": 2,
            "dayOfWeek": 0,
            "hours": 8
        },
        {
            "weekId": 2,
            "dayOfWeek": 1,
            "hours": 8
        },
        {
            "weekId": 2,
            "dayOfWeek": 2,
            "hours": 8
        },
        {
            "weekId": 2,
            "dayOfWeek": 3,
            "hours": 8
        },
        {
            "weekId": 2,
            "dayOfWeek": 4,
            "hours": 8
        }
    ]    
}'
















































