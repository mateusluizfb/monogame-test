using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Content;
using MonoGame.Extended.Tiled;

namespace MyGame.Src {
    public class Entity {

        private TiledMapObject entityTile;
        private Texture2D texture;
        private float speed = 1;
        private Vector2 positionVector;
        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;
        public String entityType;

        public Entity(TiledMapObject tile) {
            entityTile = tile;

            positionVector = new Vector2(
                (int)entityTile.Position.X,
                (int)entityTile.Position.Y
            );
        }

        public void Load(ContentManager content) {
            texture = content.Load<Texture2D>(entityTile.Type);
        }

        public void Update(GameTime gameTime, List<TiledMapTile> collisionTiles) {
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
                if ((int)tile.X == ((int)(positionVector.X + 1)/16) && (int)tile.Y == ((int)(positionVector.Y + 1)/16)) {
                    positionVector = previsousVector;
                    break;
                }
            }

            previousKeyboardState = currentKeyboardState;
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(
                texture,
                positionVector,
                Color.White
            );
        }
    }
}
