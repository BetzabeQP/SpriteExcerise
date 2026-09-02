using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpriteExercise;

public class SpriteExampleGame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D atlas;
    
    private BatSprite[] bats;

    private SpriteFont bangers;
    private SlimeGhostSprite _slimeGhost;

    /// <summary>
    /// constructs the game
    /// </summary>
    public SpriteExampleGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _slimeGhost = new();
        bats = new BatSprite[]
        {
            new BatSprite(){Position = new Vector2(100, 100), Direction = Direction.Down},
            new BatSprite(){Position = new Vector2(400, 400), Direction = Direction.Up},
            new BatSprite(){Position = new Vector2(200, 500), Direction = Direction.Left}
        };
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        _slimeGhost.LoadContent(Content);
        atlas = Content.Load<Texture2D>("colored_packed");
        foreach(var bat in bats) bat.LoadContent(Content);
        bangers = Content.Load<SpriteFont>("bangers");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        _slimeGhost.Update(gameTime);
        foreach(var bat in bats) bat.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        
        _spriteBatch.Draw(atlas, new Vector2(50, 50), new Rectangle(96, 16, 16,16), Color.White);
        foreach(var bat in bats) bat.Draw(gameTime, _spriteBatch);        
        _slimeGhost.Draw(gameTime, _spriteBatch);
        _spriteBatch.DrawString(bangers, $"{gameTime.TotalGameTime:c}", new Vector2(2,2), Color.Gold);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
