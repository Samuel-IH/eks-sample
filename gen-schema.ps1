# commands are split in case of future customization on a per-target basis

# Unity
docker run -v "$(pwd):/input" algas/quicktype /input/Schema/types.json -o /input/SlotMachine/Assets/Scripts/Schema/Types.cs --lang csharp --namespace Schema

# SlotService (.NET)
docker run -v "$(pwd):/input" algas/quicktype /input/Schema/types.json -o /input/SlotService/SlotService/Schema/Types.cs --lang csharp --namespace Schema
