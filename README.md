# Laboratorio 5
Save/Load System

## Requisitos

### 1. Clase Serializable
Se implementó la clase **GameData**, la cual es `[Serializable]`.  
Contiene los siguiente tipos de datos:  enteros, listas, cadenas, booleanos y vectores.

### 2. Datos en la Clase Serializable
`GameData` almacena:
- `currentLives` y `maxLives` para guardar las vidas del jugados.
- `coinCount` para guardar la cantidad de monedas.
- `playerPosition` para guardar la posición del jugador al llegar a un checkpoint.
- `inventoryItems` para guardar los items del inventorio que se han recogido.
- `currentSceneName` para guardar la escena.
- `collectedItemIds` para guardar ids únicos de cada item.
- `isDoorOpen` para guardar el estado de la puerta principal.
- `hasCheckpoint` para guardar si ya se llegó a un checkpoint.

### 3. Persistence Manager
El script **PersistenceManager.cs** implementa las funciones:
- `SaveSessionData(GameData data)`: guarda el estado actual en un archivo JSON dentro de `Application.persistentDataPath`.
- `LoadSessionData()`: carga los datos si el archivo existe, o maneja el error en caso contrario.

### 4. Manejo de Archivos Inexistentes
Si no se encuentra el archivo de guardado, el sistema muestra un mensaje de advertencia .

### 5. Mecanismo de Guardado y Carga
- **Menú principal**: Permite comenzar una nueva aventura o continuar desde lo último.
- **Guardado automático**: Se realiza al salir del juego o al recoger ítems persistentes.

### 6. Comprobación Visual de Datos Cargados
Al cargar una partida:
- El jugador reaparece en la posición guardada.
- Los pickups recogidos no reaparecen.
- El inventario aparece igual que antes y no se pierde la información.
- La puerta mantiene su estado anterior.
- La interfaz muestra los valores de monedas y vida correctos.
