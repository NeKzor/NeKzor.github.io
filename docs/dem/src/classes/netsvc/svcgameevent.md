# SvcGameEvent

Part of [NET/SVC](../netsvc.md) message.

The data for this message can only be decoded with [SvcGameEventList](./svcgameeventlist.md) which appears once before this message is allowed to appear.

| Name | Type | Size in bytes | Size in bits | Value |
| --- | --- | --- | --- | --- |
| Length | int | 1.375 | 11 | - |
| Data | byte[] | Length / 8 | Length | [GameEvent[]](../gameevent.md) |