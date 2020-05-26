using System;
using System.Collections.Generic;
using System.Timers;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Tiled;

namespace MyGame.Src {
    public class Enemy1 : Entity {
        private Timer aTimer;
        private Boolean timerElapsed;
        private String currentMovement;
        private String previousMovement;

        public Enemy1(TiledMapObject tile) : base(tile) {
            currentMovement = "center";
            timerElapsed = false;

            aTimer = new Timer(2000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        public override void Update(GameTime gameTime, List<TiledMapTile> collisionTiles) {
            if (timerElapsed == true) {
                if (currentMovement == "center") {
                    Console.WriteLine("Move pra baixo");
                    previousMovement = "center";
                    currentMovement = "down";
                }

                if (currentMovement == "down" && previousMovement == "center") {
                    Console.WriteLine("Move pro centro");
                    previousMovement = "down";
                    currentMovement = "center";
                }

                if (currentMovement == "up" && previousMovement == "center") {
                    Console.WriteLine("Move pro centro");

                    previousMovement = "up";
                    currentMovement = "center";
                }

                if (currentMovement == "center" && previousMovement == "down") {
                    Console.WriteLine("Move pra cima");
                    previousMovement = "center";
                    currentMovement = "up";
                }

                if (currentMovement == "center" && previousMovement == "up") {
                    Console.WriteLine("Move pra baixo");
                    previousMovement = "center";
                    currentMovement = "down";
                }

                timerElapsed = false;
            }
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e) {
            timerElapsed = true;
        }
    }
}
