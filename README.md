# Chess Morph Project

## Overview

This Unity project serves as a practical demonstration and learning experience, inspired by [Chess Morph: The Queen's Wormholes](https://store.steampowered.com/app/2209380/Chess_Morph_The_Queens_Wormholes/) by Aurea Games Studio. It is designed for educational purposes and is not intended for publication.

## Project Summary

Embark on this chessboard adventure, starting as a white queen. Capture a black piece, and you'll visually and mechanically transform into it. The cycle repeats for each captured black piece, spanning Pawn, Bishop, Rook, Knight, and Queen.

## Project Structure

### Chessboard Creation

The `GridManager` orchestrates chessboard creation. Using a double `For` loop to spawn tile prefabs ensures a dynamic and adaptable chessboard structure. Storing each spawned tile in a dictionary enhances positional referencing and overall code flexibility.

The `Tile` script, linked to each tile prefab, introduces a `GetColor` method. This method, integrated into `GridManager`, allows for an adjustable offset during tile instantiation, achieving the classic alternating color pattern on the chessboard. The inclusion of a highlighting feature, powered by Unity's Lean Tween tool, adds a subtle visual touch to enhance user experience.

### Game Manager

The Game Manager facilitates a seamless transition between initial project states:

1. **Generate Grid:** Leveraging the `GridManager` to spawn tiles systematically.
2. **Spawn Player (Queen):** Instantiating the player onto the grid.
3. **Spawn Enemies:** Generating enemy units using the `UnitManager`.

### Unit Spawning and Management

The `UnitManager` script handles player and enemy spawning, promoting efficient data management through the use of Scriptable Objects. The `scriptableUnits` Scriptable Object centralizes information about prefabs and piece types, streamlining the spawning process.

Within `UnitManager`, the `UnitData` class enhances flexibility by encapsulating references to `scriptableUnit`, `spawnPosition`, and an associated tile. This design promotes modular code, allowing customizable spawn positions for both player and enemy units.

## Player Controls

Player movement, orchestrated by the `Player Input` script, exemplifies simplicity and responsiveness. A 2D raycast is employed to seamlessly move the player to the clicked tile, ensuring an intuitive and engaging user interface.

A switch case within the player control logic dynamically handles different piece movements. Leveraging Scriptable Objects and the `MovementsManager`, this design choice ensures extensibility, making it easy to introduce new pieces with distinct behaviors.

The validation process for each piece movement prioritizes clarity and efficiency. Checks for valid moves and the presence of black pieces on target tiles contribute to a robust and reliable player control system.

In summary, this project emphasizes modular design, adherence to best practices, and a commitment to enhancing user experience through thoughtful implementation.
