docker build -t pradeepdevananth/platformservice ..\PlatformService\. 

docker push pradeepdevananth/platformservice    

docker build -t pradeepdevananth/commandsservice ..\CommandsService\.

docker push pradeepdevananth/commandsservice

kubectl rollout restart deployment platforms-depl

kubectl rollout restart deployment commands-depl


kubectl get services
kubectl get pods
kubectl get deployments
