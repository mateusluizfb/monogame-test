using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using System;
using System.Collections.Generic;

namespace MyGame.Src {
    public class Map {
        private static GraphicsDeviceManager graphics;
        private TiledMap map;
        private TiledMapRenderer mapRenderer;
        public List<Entity> entities;
        public List<TiledMapTile> wallTiles;

        public Map(GraphicsDeviceManager initianedGraphics) {
            graphics = initianedGraphics;
            entities = new List<Entity>();
            wallTiles = new List<TiledMapTile>();
        }

        public void LoadContent(ContentManager content) {
            // TODO: fazer carregar o Level2, chamar o Luiz
            map = content.Load<TiledMap>("Map1");
            mapRenderer = new TiledMapRenderer(graphics.GraphicsDevice, map);

            var objectsLayer = map.GetLayer<TiledMapObjectLayer>("Object Layer 1");
            var wallLayer = map.GetLayer<TiledMapTileLayer>("Wall Layer");

            foreach (var i in objectsLayer.Objects) {
                if (i.Type == "Yoda") {
                    Player yoda = new Player(i);
                    entities.Add(yoda);
                }

                if (i.Type == "Enemy1") {
                    Enemy1 enemy1 = new Enemy1(i);
                    entities.Add(enemy1);
                }
            }

            foreach (var i in wallLayer.Tiles) {
                wallTiles.Add(i);
            }

            entities.ForEach(entity => { entity.Load(content); });
        }

        public void Update(GameTime gameTime) {
            mapRenderer.Update(gameTime);
            entities.ForEach(entity => { entity.Update(gameTime, wallTiles); });
        }

        public void Draw(OrthographicCamera camera, SpriteBatch spriteBatch) {
            var viewMatrix = camera.GetViewMatrix();
            mapRenderer.Draw(viewMatrix);
            entities.ForEach(entity => { entity.Draw(spriteBatch); });
        }
    }
}

