using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame3
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private mapa mimapa;
        private personaje principal;
        private Boolean mapaVisible;
        private interfaz inter;
        private Malo1 malo1;
        private Malo2 malo2;
        fondo fon;
        GraphicsDevice device;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 425;
            graphics.PreferredBackBufferWidth = 675;
            Content.RootDirectory = "Content";
            mimapa = new mapa(device);
            principal = new personaje(device);
            principal.setPosicion(new Vector2(250,150));
            mapaVisible = false;

            malo1 = new Malo1(principal);
            malo2 = new Malo2(new Vector2(-300, 300), principal);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            device = graphics.GraphicsDevice;
 
            // TODO: use this.Content to load your game content here
            Texture2D ima;
            ima = Content.Load<Texture2D>("mapa");
            mimapa.fondo = ima;
            Texture2D ima2 = Content.Load<Texture2D>("cursor/0001");
            mimapa.cursor.agregarImagenes(ima2, 1);
            Texture2D ima3 = Content.Load<Texture2D>("cursor/0002");
            mimapa.cursor.agregarImagenes(ima3, 2);

            mimapa.fuente = Content.Load<SpriteFont>("SpriteFont1");

            //personaje
            ima = Content.Load<Texture2D>("personaje_camina/0016");
            principal.agregarImagenes(ima, 1);
            ima = Content.Load<Texture2D>("personaje_camina/0001");
            principal.agregarImagenes(ima, 2);
            ima = Content.Load<Texture2D>("personaje_camina/0003");
            principal.agregarImagenes(ima, 3);
            ima = Content.Load<Texture2D>("personaje_camina/0005");
            principal.agregarImagenes(ima, 4);
            ima = Content.Load<Texture2D>("personaje_camina/0007");
            principal.agregarImagenes(ima, 5);
            ima = Content.Load<Texture2D>("personaje_camina/0009");
            principal.agregarImagenes(ima, 6);
            ima = Content.Load<Texture2D>("personaje_camina/0011");
            principal.agregarImagenes(ima, 7);
            ima = Content.Load<Texture2D>("personaje_camina/0013");
            principal.agregarImagenes(ima, 8);
            ima = Content.Load<Texture2D>("personaje_camina/0015");
            principal.agregarImagenes(ima, 9);
            ima = Content.Load<Texture2D>("personaje_camina/0017");
            principal.agregarImagenes(ima, 10);
            ima = Content.Load<Texture2D>("personaje_camina/0019");
            principal.agregarImagenes(ima, 11);
            ima = Content.Load<Texture2D>("personaje_camina/0020");
            principal.agregarImagenes(ima, 12);

            //personaje ataque 3

            ima = Content.Load<Texture2D>("personaje_ataca_basico/0002");
            principal.agregarImagenes(ima, 13);
            ima = Content.Load<Texture2D>("personaje_ataca_basico/0004");
            principal.agregarImagenes(ima, 14);
            ima = Content.Load<Texture2D>("personaje_ataca_basico/0006");
            principal.agregarImagenes(ima, 15);
            ima = Content.Load<Texture2D>("personaje_ataca_basico/0008");
            principal.agregarImagenes(ima, 16);
            ima = Content.Load<Texture2D>("personaje_ataca_basico/0010");
            principal.agregarImagenes(ima, 17);
            ima = Content.Load<Texture2D>("personaje_ataca_basico/0012");
            principal.agregarImagenes(ima, 18);
            ima = Content.Load<Texture2D>("personaje_ataca_basico/0014");
            principal.agregarImagenes(ima, 19);
            ima = Content.Load<Texture2D>("personaje_ataca_basico/0016");
            principal.agregarImagenes(ima, 20);
            ima = Content.Load<Texture2D>("personaje_ataca_basico/0017");
            principal.agregarImagenes(ima, 21);
            ima = Content.Load<Texture2D>("personaje_ataca_basico/0018");
            principal.agregarImagenes(ima, 22);
            ima = Content.Load<Texture2D>("personaje_ataca_basico/0019");
            principal.agregarImagenes(ima, 23);
            ima = Content.Load<Texture2D>("personaje_ataca_basico/0020");
            principal.agregarImagenes(ima, 24);
            
            // poder
            principal.agregarPoderes(Content);

            //terreno
            fon = new fondo(Content,device);

            //interfaz
            inter = new interfaz(Content);

            //malo1
            Texture2D imaE;
            imaE = Content.Load<Texture2D>("malo1/001");
            malo1.agregarimagen(imaE, 1);
            imaE = Content.Load<Texture2D>("malo1/002");
            malo1.agregarimagen(imaE, 2);
            imaE = Content.Load<Texture2D>("malo1/003");
            malo1.agregarimagen(imaE, 3);
            imaE = Content.Load<Texture2D>("malo1/004");
            malo1.agregarimagen(imaE, 4);
            imaE = Content.Load<Texture2D>("malo1/005");
            malo1.agregarimagen(imaE, 5);
            imaE = Content.Load<Texture2D>("malo1/006");
            malo1.agregarimagen(imaE, 6);
            imaE = Content.Load<Texture2D>("malo1/007");
            malo1.agregarimagen(imaE, 7);
            imaE = Content.Load<Texture2D>("malo1/008");
            malo1.agregarimagen(imaE, 8);
            imaE = Content.Load<Texture2D>("malo1/009");
            malo1.agregarimagen(imaE, 9);
            imaE = Content.Load<Texture2D>("malo1/010");
            malo1.agregarimagen(imaE, 10);
            
            //maloataca1
            imaE = Content.Load<Texture2D>("malo1ataca/0001");
            malo1.agregarimagen(imaE, 11);
            imaE = Content.Load<Texture2D>("malo1ataca/0002");
            malo1.agregarimagen(imaE, 12);
            imaE = Content.Load<Texture2D>("malo1ataca/0003");
            malo1.agregarimagen(imaE, 13);
            imaE = Content.Load<Texture2D>("malo1ataca/0004");
            malo1.agregarimagen(imaE, 14);
            imaE = Content.Load<Texture2D>("malo1ataca/0005");
            malo1.agregarimagen(imaE, 15);
            imaE = Content.Load<Texture2D>("malo1ataca/0006");
            malo1.agregarimagen(imaE, 16);
            imaE = Content.Load<Texture2D>("malo1ataca/0007");
            malo1.agregarimagen(imaE, 17);
            imaE = Content.Load<Texture2D>("malo1ataca/0008");
            malo1.agregarimagen(imaE, 18);
            imaE = Content.Load<Texture2D>("malo1ataca/0009");
            malo1.agregarimagen(imaE, 19);
            imaE = Content.Load<Texture2D>("malo1ataca/0010");
            malo1.agregarimagen(imaE, 20);

            //malo2
            Texture2D imaE2;
            imaE2 = Content.Load<Texture2D>("malo2/0001");
            malo2.agregarimagen(imaE2, 1);
            imaE2 = Content.Load<Texture2D>("malo2/0002");
            malo2.agregarimagen(imaE2, 2);
            imaE2 = Content.Load<Texture2D>("malo2/0003");
            malo2.agregarimagen(imaE2, 3);
            imaE2 = Content.Load<Texture2D>("malo2/0004");
            malo2.agregarimagen(imaE2, 4);
            imaE2 = Content.Load<Texture2D>("malo2/0005");
            malo2.agregarimagen(imaE2, 5);
            imaE2 = Content.Load<Texture2D>("malo2/0006");
            malo2.agregarimagen(imaE2, 6);
            imaE2 = Content.Load<Texture2D>("malo2/0007");
            malo2.agregarimagen(imaE2, 7);
            imaE2 = Content.Load<Texture2D>("malo2/0008");
            malo2.agregarimagen(imaE2,8);
            imaE2 = Content.Load<Texture2D>("malo2/0009");
            malo2.agregarimagen(imaE2, 9);
            imaE2 = Content.Load<Texture2D>("malo2/0010");
            malo2.agregarimagen(imaE2, 10);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            botones(gameTime);
            mimapa.update(gameTime);
            principal.update2(gameTime);
           malo1.update(gameTime);
            malo2.update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            fon.draw(spriteBatch);
            principal.draw2(spriteBatch);
            inter.draw(spriteBatch);
            mimapa.draw(spriteBatch);
            malo1.draw(spriteBatch);
            malo2.draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void botones(GameTime gameTime)
        {
            KeyboardState keystate = Keyboard.GetState();
            GamePadState gamepadstate = GamePad.GetState(PlayerIndex.One);
            
            if (keystate.IsKeyDown(Keys.M) || gamepadstate.DPad.Up == ButtonState.Pressed)
            {
                if (!mapaVisible)
                {
                    mimapa.mostrarMapa();
                    mapaVisible = true;
                }
                else {
                    mimapa.ocultarMapa();
                    mapaVisible = false;
                }
            }
            if (keystate.IsKeyDown(Keys.N) || gamepadstate.DPad.Up == ButtonState.Pressed)
            {
                principal.caminar();
            }

            if (keystate.IsKeyDown(Keys.D) || gamepadstate.DPad.Up == ButtonState.Pressed)
            {
                mimapa.siguiente();
            }

            if (keystate.IsKeyDown(Keys.A) || gamepadstate.DPad.Up == ButtonState.Pressed)
            {
                mimapa.anterior();

            }

            //movimiento\\


            if ((keystate.IsKeyDown(Keys.Up) || gamepadstate.DPad.Up == ButtonState.Pressed) && principal.posicion.Y > 70)
            {
                principal.arriba();
                principal.caminar();
            }

            if ((keystate.IsKeyDown(Keys.Down) || gamepadstate.DPad.Down == ButtonState.Pressed)&&principal.posicion.Y<250)
            {
                principal.abajo();
                principal.caminar();
            }

            if ((keystate.IsKeyDown(Keys.Left) || gamepadstate.DPad.Left == ButtonState.Pressed) && principal.posicion.X > 0)
            {
                principal.izquierda();
                principal.caminar();

            }

            if ((keystate.IsKeyDown(Keys.Right) || gamepadstate.DPad.Right == ButtonState.Pressed) && principal.posicion.X < 540)
            {
                principal.derecha();
                principal.caminar();
            }

            if (keystate.IsKeyUp(Keys.Up) && keystate.IsKeyUp(Keys.Down) && keystate.IsKeyUp(Keys.Left) && keystate.IsKeyUp(Keys.Right))
            {
                principal.esperar();
            }

            // lanzar poderes
            if (keystate.IsKeyDown(Keys.D3) || gamepadstate.DPad.Right == ButtonState.Pressed)
            {
                principal.atacar();
                principal.poderActual = 2;
                principal.poderes[2].ejecutar();
            }

            if (keystate.IsKeyDown(Keys.D2) || gamepadstate.DPad.Right == ButtonState.Pressed)
            {
                principal.atacar();
                principal.poderActual = 1;
                principal.poderes[1].ejecutar();
            }

            if (keystate.IsKeyDown(Keys.D1) || gamepadstate.DPad.Right == ButtonState.Pressed)
            {
                principal.atacar();
                principal.poderActual = 0;
                principal.poderes[0].ejecutar();
            }

            if (keystate.IsKeyDown(Keys.D4) || gamepadstate.DPad.Right == ButtonState.Pressed)
            {
                principal.atacar();
                principal.poderActual = 3;
                principal.poderes[3].ejecutar();
            }

            //cambiar fondo
            if (keystate.IsKeyDown(Keys.C))
            {
                fon = new fondo(Content, device);

            }

        
        }
    }
}
