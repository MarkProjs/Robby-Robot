using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RobbyTheRobot;

namespace RobbyVisulizer
{
    public class RobbyVisulizerGame : Game
    {
        private Random rnd;
        private int x;
        private int y;
        private GraphicsDeviceManager _graphics;

        private SpriteBatch _spriteBatch;

        private SpriteFont _scoreFont;
        private double _scoreNum = 0;
        private SpriteFont _moveFont;
        private int _moveNum = 0;
        private SpriteFont _genFont;
        private int _genNum = 0;

        private IRobbyTheRobot _robby;
        private Grid grid;

        private Grid robby;

        private string _gen;
        private string _robyaction;
        private  int[] _robyActionNum;
        private ContentsOfGrid[,] _gridContent;


        public RobbyVisulizerGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _robby = Robby.CreateRobby(1000, 200, 100);
            rnd = new Random();
            x = rnd.Next(0, 10);
            y = rnd.Next(0, 10);

        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferHeight = 700;
            _graphics.PreferredBackBufferWidth = 500;
            _graphics.ApplyChanges();
            _gridContent = _robby.GenerateRandomTestGrid();
            // this.grid = new RobbyGrid(this, _robyaction[0,0],_robyaction[]);
            for (int i = 0; i < _gridContent.GetLength(0); i++)
            {
                for (int j = 0; j < _gridContent.GetLength(1); j++)
                {
                    // if(i == 0 || i == _gridContent.GetLength(0)-1 || j == 0 || j == _gridContent.GetLength(1)-1)
                    // {
                    //     this.grid = new WallGrid(this, i, j);
                    //     Components.Add(this.grid);
                    // }
                    
                    if (_gridContent[i, j] is ContentsOfGrid.Can)
                    {
                        this.grid = new CanGrid(this, i, j);
                        Components.Add(this.grid);
                    }
                    else if (_gridContent[i, j] is ContentsOfGrid.Empty)
                    {
                        this.grid = new EmptyGrid(this, i, j);
                        Components.Add(this.grid);
                    }
                }
            }
            robby = new RobbyGrid(this, this.x, this.y);
            Components.Add(robby);

            Splitter("../Generations/Generation1.txt");
            _robyActionNum = new int[_robyaction.Length];
            for(int i = 0; i < _robyaction.Length; i++){
                _robyActionNum[i] = Convert.ToInt32(_robyaction[i]);
            }
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _scoreFont = Content.Load<SpriteFont>("Score");
            _moveFont = Content.Load<SpriteFont>("Move");
            _genFont = Content.Load<SpriteFont>("Generation");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //TO DO: THE LOGIC PART
            for (int i = 0; i < _robyActionNum.Length;i++) 
            {
                switch(_robyActionNum[i])
                {
                    case 0:
                        (robby as RobbyGrid).Up += 1;
                        _moveNum++;
                        break;
                    case 1:
                        (robby as RobbyGrid).Up -= 1;
                        _moveNum++;
                        break;
                    case 2:
                        (robby as RobbyGrid).Left += 1;
                        _moveNum++;
                        break;
                    case 3:
                        (robby as RobbyGrid).Left -= 1;
                        _moveNum++;
                        break;
                    case 4:
                        _moveNum++;
                        break;
                    case 5:
                        _moveNum++;
                        break;
                    case 6:
                        _moveNum++;
                        break;
                }
            }
           
            _scoreNum += Robby.ScoreForAllele(_robyActionNum, _gridContent, rnd, ref this.x, ref this.y);
            Debug.WriteLine(_scoreNum);
            _genNum = Convert.ToInt32(_gen);
            // Splitter();
            // _robyActionNum = new int[_robyaction.Length];
            // for(int i = 0; i < _robyaction.Length; i++){
            //     _robyActionNum[i] = Int32.Parse(_robyaction[i]);
            // }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.DrawString(_genFont, "Generation: " + _genNum, new Vector2(0,520), Color.Black);
            _spriteBatch.DrawString(_moveFont, "Move: " + _moveNum + "/200", new Vector2(0,560), Color.Black);
            _spriteBatch.DrawString(_scoreFont, "Points: " + _scoreNum + "/500", new Vector2(0,600), Color.Black);
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        private void Splitter(string path)
        {
            string rootFile = FileReader(path);
            string[] tmpFile = rootFile.Split(";");
            _gen = tmpFile[3];
            _robyaction = tmpFile[4];
        }

        private static string FileReader(string path)
        {   
            string chromosomes = "";
            try
            {
                using(var sr = new StreamReader(path))
                {
                    chromosomes = sr.ReadLine();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        
            return chromosomes;
        }
    }
}