# ELK (Elastic Logstash Kibana) 101

## Run ELK stack in Docker containers. 

1. app (with FileBeat) -> A sample api to generate some log data, and filebeat ships the log data to logstash
2. logstash - ingest the log data, transform it, and send it to ElasticSearch for storage
3. elasticsearch -  store the transformed log data
4. kibana - UI to query/analyze log 

```
docker-compose up -d
```

## Generate an error log in the app
```
curl -d '{"message": "testing"}' -H "Content-Type: application/json" -X POST http://localhost:5001/Error
```

## Create index pattern in Kibana
```
/bin/sh create-index-pattern.sh
```
