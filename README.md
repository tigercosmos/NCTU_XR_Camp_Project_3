# NCTU XR Camp Project 3
## Scene
- Init
    - 只包含相機與前往下一個scene的控制物件
    - 所有demo都要從這個scene開始，因為只有這裡有相機
    - 更改GoToStart的內容即可決定要直接跳往哪個scene
- Start
    - 開始畫面
    - play -> 前往WarmUp
    - exit -> console會顯示Exit
- WarmUp
    - 暖身
    - start -> 開始暖身
    - X -> 直接前往GameLevel
:::warning
目前按下Start會直接暖身完畢，還沒有辦法播影片
:::
- GameLevel
    - 選擇難度
    - 選擇任何難度都會前往MusicSelect
    - X -> 回到Start
- MusicSelect
    - 選擇音樂
    - 選擇任何音樂都會前往Running
    - X -> 回到GameLevel
- Running
    - 起初，需要先對齊跑道，點選go，就會直接開始
    - 除了三個按鈕外，其餘UI都會跟著頭部的動作
    - music -> 前往MusicChange
    - pause -> console會顯示Pause
    - exit -> 前往Score
- MusicChange
    - 更換音樂
    - 選擇任何音樂都會跳回Running，而且需重新對齊跑道
    - 下面三個按鈕目前沒有作用
    - X -> 回至Running，且須重新對齊跑道
- Score
    - 結算畫面
    - X -> 回至Start
## hierarchy
## Scripts
