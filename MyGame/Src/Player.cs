using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Tiled;

namespace MyGame.Src {
    public class Player : Entity {
        public Player(TiledMapObject tile) : base(tile) {
        }

        public override void Update(GameTime gameTime, List<TiledMapTile> collisionTiles) {
            currentKeyboardState = Keyboard.GetState();
            Vector2 previsousVector = positionVector;

            if (currentKeyboardState.IsKeyDown(Keys.Up) && previousKeyboardState.IsKeyUp(Keys.Up)) {
                positionVector -= new Vector2(0, 16);
            }

            if (currentKeyboardState.IsKeyDown(Keys.Down) && previousKeyboardState.IsKeyUp(Keys.Down)) {
                positionVector += new Vector2(0, 16);
            }

            if (currentKeyboardState.IsKeyDown(Keys.Left) && previousKeyboardState.IsKeyUp(Keys.Left)) {
                positionVector -= new Vector2(16, 0);
            }

            if (currentKeyboardState.IsKeyDown(Keys.Right) && previousKeyboardState.IsKeyUp(Keys.Right)) {
                positionVector += new Vector2(16, 0);
            }

            // COLLISION LOGIC
            foreach (var tile in collisionTiles) {
                if ((int)tile.X == ((int)(positionVector.X + 1) / 16) && (int)tile.Y == ((int)(positionVector.Y + 1) / 16)) {
                    positionVector = previsousVector;
                    break;
                }
            }

            previousKeyboardState = currentKeyboardState;
        }
    }
}
