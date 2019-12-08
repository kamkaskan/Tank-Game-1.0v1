# Tank-Game-1.0v1
Test game for a job interview

Możliwość ustawienia:
  ilości przeciwników (1-8)
  czołgu gracza (1-3, ScriptableObject)
  czołgu przeciwników (1-3, ScriptableObject))
  poziomu trudności (easy, normal, hard, ScriptableObject)
  granej mapy (1 z dostępnych w Resources/maps jako JSON)
    map editor: https://docs.google.com/spreadsheets/d/1ns-LEgjwdfHRTqq9njLIETZ6K_8uhWBSo9HdgJL_sfY/edit#gid=1131200506
  
Sterowanie czołgiem za pomocą WASD/Strzałki + mysz. 
  Czołg stara się jechać w kierunku wyznaczonym przez strzałki (obraca się powoli), podobnie lufa która stara się nadążać za myszką.

AI opiera się na unitowskim NavMesh'u i działa na zasadzie: 
  jeśli widzisz cel i jesteś wystarczająco blisko to strzelaj, inaczej spróbuj się zbliżyć do celu
  Wykorzystuje w pełni te same funkcje co gracz (różnica taka że przekazuje je AiController a nie InputController)
  
Minimapa to RenderTexture'a która widzi tylko konkretny Layer.

Na mapie co 10 sekund pojawia się znajdźka zapewniająca nietykalność.
