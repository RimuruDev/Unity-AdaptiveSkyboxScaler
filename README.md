# AdaptiveSkyboxScaler

## Overview

`AdaptiveSkyboxScaler` is a Unity component designed to scale skybox textures proportionally to fit any screen format or platform. This is particularly useful for projects with numerous scenes and different skyboxes, ensuring a consistent and correct display across various devices.

## Features

- Automatically scales skybox textures to maintain correct aspect ratios.
- Easily integrates with existing projects with minimal setup.
- Optimized to cache components and minimize performance impact.

## Installation

1. Copy the `AdaptiveSkyboxScaler` script into your Unity project.
2. Attach the script to the main camera or any other appropriate game object.
3. Assign a `SpriteRenderer` component to the `backgroundSpriteRenderer` field in the inspector.

## Usage

1. Ensure each scene has a skybox assigned in the `RenderSettings`.
2. The script will automatically find the main camera and skybox texture.
3. It will create a sprite from the skybox texture and assign it to the `SpriteRenderer`.
4. The script will scale the sprite to fit the screen size proportionally.

## TODO
1. Add the ability to install a camera if I do not use the “MainCamera” tag system.
2. Add a mode for automatically creating SpriteRenderer settings and installations without specifying your own SpriteRenderer.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

