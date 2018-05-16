# .dem

## Overview
- [Demo](#demo)
- [Message](#message)
  - [Types](#types)
- [Message Data](#message-data)
  - [SignOn & Packet](#signon--packet)
  - [SyncTick](#synctick)
  - [ConsoleCmd](#consolecmd)
  - [UserCmd](#usercmd)
  - [Stop](#stop)
  - [CustomData](#customdata)
  - [StringTables](#stringtables)
- [Data Objects](#data-objects)
  - [CmdInfo](#cmdinfo)
  - [NET/SVC Message](#netsvc-message)
    - [Types](#types-1)
  - [UserCmdInfo](#usercmdinfo)
  - [SendTable](#sendtable)
  - [ServerClassInfo](#serverclassinfo)

## Demo

| Name | Type | Size in bytes | Size in bits | Value |
| --- | --- | --- | --- | --- |
| DemoFileStamp | string | 8 | 64 | HL2DEMO\0 |
| DemoProtocol | int | 4 | 32 | - |
| NetworkProtocol | int | 4 | 32 | - |
| ServerName | string | 260 | 2080 | - |
| ClientName | string | 260 | 2080 | - |
| MapName | string | 260 | 2080 | - |
| GameDirectory | string | 260 | 2080 | - |
| PlaybackTime | float | 4 | 32 | - |
| PlaybackTicks | int | 4 | 32 | - |
| PlaybackFrames | int | 4 | 32 | - |
| SignOnLength | int | 4 | 32 | - |
| DemoMessages | [Message[]](#message) | - | - | - |

## Message

| Name | Type | Size in bytes | Size in bits | Value |
| --- | --- | --- | --- | --- |
| Type | [Message Type](#types) | 1 | 8 | - |
| Tick | int | 4 | 32 | - |
| Alignment | byte | 1 | 8 | Optional |
| Data | [Message Data](#message-data) | - | - | - |

### Types

| Name | Value | Description |
| --- | --- | --- |
| [SignOn](#signon--packet) | 1 | - |
| [Packet](#signon--packet) | 2 | - |
| [SyncTick](#synctick) | 3 | - |
| [Consolecmd](#consolecmd) | 4 | - |
| [Usercmd](#usercmd) | 5 | - |
| [DataTables](#datatables) | 6 | - |
| [Stop](#dem_stop) | 7 | - |
| [CustomData](#customdata) | 8 | - |
| [StringTables](#stringtables) | 9 | 8 in old engines. |

## Message Data

### SignOn & Packet

| Name | Type | Size in bytes | Size in bits | Value |
| --- | --- | --- | --- | --- |
| PacketInfo | byte[] | 76\*MSSC¹ | 76\*MSSC\*8 | [CmdInfo[MSSC]](#cmdinfo) |
| InSequence | int | 4 | 32 | - |
| OutSequence | int | 4 | 32 | - |
| Size | int | 4 | 32 | - |
| Data | byte[] | Size | Size*8 | [NET/SVC-Message[]](#netsvc-message) |

¹MSSC (MaxSplitScreenClients) can be greater than 1 for multiplayer games but default is 1.

### SyncTick
This message does not contain any data.

### ConsoleCmd

| Name | Type | Size in bytes | Size in bits | Value |
| --- | --- | --- | --- | --- |
| Size | int | 4 | 32 | - |
| Data | string | Size | Size*8 | - |

### UserCmd

| Name | Type | Size in bytes | Size in bits | Value |
| --- | --- | --- | --- | --- |
| Cmd | int | 4 | 32 | - |
| Size | int | 4 | 32 | - |
| Data | byte[] | Size | Size*8 | [UserCmdInfo](#usercmdinfo) |
| Size | int | 4 | 32 | - |
| Data | byte[] | Size | Size*8 | [SendTable[]](#sendtable)<br>[ServerClassInfo[]](#serverclassinfo) |

### Stop

| Name | Type | Size in bytes | Size in bits | Value |
| --- | --- | --- | --- | --- |
| RemainingData | byte[] | - | - | Optional |

### CustomData

| Name | Type | Size in bytes | Size in bits | Value |
| --- | --- | --- | --- | --- |
| Unknown | int | 4 | 32 | - |
| Size | int | 4 | 32 | - |
| Data | byte[] | Size | Size*8 | - |

### StringTables

| Name | Type | Size in bytes | Size in bits | Value |
| --- | --- | --- | --- | --- |
| Size | int | 4 | 32 | - |
| Data | byte[] | Size | Size*8 | [StringTable[]](#stringtable) |

## Data Objects

### CmdInfo

| Name | Type | Size in bytes | Size in bits | Value |
| --- | --- | --- | --- | --- |
| Flags | int | 4 | 32 | - |
| ViewOrigin | float[] | 12 | 96 | - |
| ViewAngles | float[] | 12 | 96 | - |
| LocalViewAngles | float[] | 12 | 96 | - |
| ViewOrigin2 | float[] | 12 | 96 | - |
| ViewAngles2 | float[] | 12 | 96 | - |
| LocalViewAngles2 | float[] | 12 | 96 | - |

### NET/SVC Message

| Name | Type | Size in bytes | Size in bits | Value |
| --- | --- | --- | --- | --- |
| Type | [Message Type](#types-1) | 0.75 | 6 | - |
| Data | byte[] | - | - | - |

#### Types

| Name | Value | Description |
| --- | --- | --- |
| NetNop | 0 | - |
| NetDisconnect | 1 | - |
| NetFile | 2 | - |
| NetSplitScreenUser | 3 | New engines. |
| NetTick | 4 | 3 in old engines. |
| NetStringCmd | 5 | 4 in old engines. |
| NetSetConVar | 6 | 5 in old engines. |
| NetSignonState | 7 | 6 in old engines. |
| SvcServerInfo | 8 | - |
| SvcSendTable | 9 | - |
| SvcClassInfo | 10 | - |
| SvcSetPause | 11 | - |
| SvcCreateStringTable | 12 | - |
| SvcUpdateStringTable | 13 | - |
| SvcVoiceInit | 14 | - |
| SvcVoiceData | 15 | - |
| SvcPrint | 16 | 7 in old engines. |
| SvcSounds | 17 | - |
| SvcSetView | 18 | - |
| SvcFixAngle | 19 | - |
| SvcCrosshairAngle | 20 | - |
| SvcBspDecal | 21 | - |
| SvcSplitScreen | 22 | New engines. |
| SvcUserMessage | 23 | - |
| SvcEntityMessage | 24 | - |
| SvcGameEvent | 25 | - |
| SvcPacketEntities | 26 | - |
| SvcTempEntities | 27 | - |
| SvcPrefetch | 28 | - |
| SvcMenu | 29 | - |
| SvcGameEventList | 30 | - |
| SvcGetCvarValue | 31 | - |
| SvcCmdKeyValues | 32 | - |

### UserCmdInfo

| Name | Type | Size in bytes | Size in bits | Value |
| --- | --- | --- | --- | --- |
| CommandNumber | int | 4 | 32 | Optional |
| TickCount | int | 4 | 32 | Optional |
| ViewAngles | float[] | 12 | 96 | Optional |
| SideMove | float | 4 | 32 | Optional |
| ForwardMove | float | 4 | 32 | Optional |
| UpMove | float | 4 | 32 | Optional |
| Buttons | int | 4 | 32 | Optional |
| Impulse | byte | 1 | 8 | Optional |
| WeaponSelect | int | 1.375 | 11 | Optional |
| WeaponSubtype | int | 0.75 | 6 | Optional |
| MouseDx | short | 2 | 16 | Optional |
| MouseDy | short | 2 | 16 | Optional |

### SendTable
Optional.

| Name | Type | Size in bytes | Size in bits | Value |
| --- | --- | --- | --- | --- |
| NeedsDecoder | bool | 0.125 | 1 | - |
| NetTableName | string | - | - | - |
| NumOfProps | int | 1.25 | 10 | - |
| SendPropType | int | 0.625 | 5 | - |
| SendPropName | string | - | - | - |
| SendPropFlags | int | 2<br>1.375 OE | 16<br>11 OE | - |

### ServerClassInfo

| Name | Type | Size in bytes | Size in bits | Value |
| --- | --- | --- | --- | --- |
| NumOfClasses | short | 2 | 16 | - |
| ClassId | short | 2 | 16 | - |
| ClassName | string | - | - | - |
| DataTableName | string | - | - | - |

### StringTable

| Name | Type | Size in bytes | Size in bits | Value |
| --- | --- | --- | --- | --- |
| NumOfTables | int | 1 | 8 | - |
| TableName | string | - | - | - |
| NumOfEntries| short | 2 | 16 | - |
| EntryName | string | - | - | - |
| EntrySize | short | 2 | 16 | Optional |
| EntryData | byte[] | EntrySize | EntrySize*8 | Optional |
| NumOfClientEntries | short | 2 | 16 | Optional |
| ClientEntryName | string | - | - | Optional |
| ClientEntrySize | short | 2 | 16 | Optional |
| ClientEntryData | byte[] | ClientEntrySize | ClientEntrySize*8 | Optional |