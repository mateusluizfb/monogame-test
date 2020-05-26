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

        protected TiledMapObject entityTile;
        protected Texture2D texture;
        protected float speed = 1;
        protected Vector2 positionVector;
        protected KeyboardState currentKeyboardState;
        protected KeyboardState previousKeyboardState;
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

        public virtual void Update(GameTime gameTime, List<TiledMapTile> collisionTiles) {
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
