#!/bin/zsh

sass --load-path=src/LostHarbor.Game/Styles src/LostHarbor.Game/Styles:src/LostHarbor.Game/wwwroot/css src/LostHarbor.Game/Pages:src/LostHarbor.Game/Pages src/LostHarbor.Game/Shared:src/LostHarbor.Game/Shared --style=compressed --update
