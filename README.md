# Text Analyser Api

### Run locally
```
docker build . -t {containerName}

docker run -d \
-e PORT='5000' \
-e IBMCredentials__WatsonApiKey='{watsonKey}' \
-e IBMCredentials__WatsonVersionDate='{watsonVersionDate}' \
-e GoogleCredentials__ApiKey='{googleApiKey}' \
-e GoogleCredentials__SearchEngineId='{googleSearchEngineId}' \
-p 5000:5000 -it {containerName}
```

### Heroku Deployment
```
heroku stack:set container -a <project>
git push heroku master
```

### IBM Watson Api
https://www.ibm.com/watson/services/natural-language-understanding/