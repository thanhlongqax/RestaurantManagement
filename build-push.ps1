$dockerhub = "thanhlongqax"
$project = "restaurant-mgmt"

$services = @{
    "api-gateway" = "ApiGateway/Dockerfile"
    "fileservice" = "FileServices/Dockerfile"
    "orderservice" = "OrderServices/Dockerfile"
    "userservice" = "UserService/Dockerfile"
    "tableservice" = "TableServices/Dockerfile"
    "menuservice" = "MenuServices/Dockerfile"
    "kitchenservice" = "KitchenServices/Dockerfile"
}

foreach ($service in $services.Keys) {
    $dockerfile = $services[$service]
    $image = "$dockerhub/$project-$service:latest"

    Write-Host "🚀 Building $service => $image" -ForegroundColor Cyan
    docker build -t $image -f $dockerfile .

    Write-Host "📤 Pushing $image" -ForegroundColor Yellow
    docker push $image

    Write-Host "✅ Done: $service" -ForegroundColor Green
    Write-Host "--------------------------------------" -ForegroundColor DarkGray
}
