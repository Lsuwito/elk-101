#!/bin/sh

curl -X POST http://localhost:5601/api/saved_objects/index-pattern/my-pattern  -H 'kbn-xsrf: true' -H 'Content-Type: application/json' -d '{"attributes": { "title": "logstash", "sourceFilters":"[{\"value\":\"agent*\"},{\"value\":\"log.*\"},{\"value\":\"input.*\"},{\"value\":\"geoip*\"},{\"value\":\"ecs*\"},{\"value\":\"tags*\"},{\"value\":\"*.keyword\"}]" }}'
