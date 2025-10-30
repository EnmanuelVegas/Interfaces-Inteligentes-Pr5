# Interfaces Inteligentes - Escenas Cardboard

- **Enmanuel Vegas Acosta** (alu0101281698)
- **Práctica 5**: Escenas Cardboard

## **Ejercicio propuesto**

1. _Crear el proyecto Cardboard y experimentar y generar una apk para Android._
![ejercicio1](./images/ej1.gif)

2. _Crea una escena con Cardboard que el jugador recolecte con la vista._

Para este ejercicio se han de seleccionar con la vista los elementos que representen alimentos (pollos, zanahorias, manzanas, etc.) que serán recolectados en el fuego que está presente.
Los alimentos tienen [este script](/scripts/ObjectControllerFood.cs) asociado.

![ejercicio2](./images/ej2.gif)

3. _Elige un objeto en la escena que, cuando el jugador lo selecciona con la vista, todos los elementos sean recolectados_

En este caso, cuando el jugador selecciona con la vista la caja fuerte presente en la escena, todos los elementos de monedas son recolectados hacia ella
La caja fuerte tiene [este script](/scripts/ObjectControllerSafe.cs) asociado.

![ejercicio3](./images/ej3.gif)
