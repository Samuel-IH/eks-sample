# commands are split in case of future customization on a per-target basis

# Unity
docker run --rm -v "$(PWD):/local" openapitools/openapi-generator-cli generate -i /local/Schema/slot-service.yaml -g csharp -o /local/SlotMachine/Assets/Scripts/Schema --additional-properties=library=unityWebRequest