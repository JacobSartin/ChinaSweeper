using System;
using System.Reflection;
using Xamarin.Forms;

namespace ChinaSweeper.Model
{
    public enum TileStatus
    {
        Hidden,
        Flagged,
        Exposed
    }

    public class Tile : Frame
    {
        TileStatus tileStatus = TileStatus.Hidden;
        readonly Label label;
        private readonly Image flagImage;
        private readonly Image mineImage;
        static readonly ImageSource flagImageSource;
        static readonly ImageSource mineImageSource;
        bool doNotFireEvent;

        public event EventHandler<TileStatus> TileStatusChanged;

        static Tile()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            flagImageSource = ImageSource.FromResource("ChinaSweeper.Resources.Images.Flag.png", assembly);
            mineImageSource = ImageSource.FromResource("ChinaSweeper.Resources.Images.Mine.png", assembly);
        }

        public Tile(int row, int col)
        {
            Row = row;
            Col = col;

            BackgroundColor = Color.FromHex("#FFDF280F"); //Red
            BorderColor = Color.FromHex("#FFFFDF00"); //Gold
            Padding = 2;

            label = new Label
            {
                Text = " ",
                TextColor = Color.FromHex("#FFDF280F"), //Red
                BackgroundColor = Color.FromHex("#FFFFDF00"), //Gold
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
            };

            flagImage = new Image
            {
                Source = flagImageSource,

            };

            mineImage = new Image
            {
                Source = mineImageSource
            };

            TapGestureRecognizer singleTap = new TapGestureRecognizer
            {
                NumberOfTapsRequired = 1
            };
            singleTap.Tapped += OnSingleTap;
            GestureRecognizers.Add(singleTap);


            TapGestureRecognizer doubleTap = new TapGestureRecognizer
            {
                NumberOfTapsRequired = 2
            };
            doubleTap.Tapped += OnDoubleTap;
            GestureRecognizers.Add(doubleTap);


        }

        public int Row { private set; get; }

        public int Col { private set; get; }

        public bool IsMine { set; get; }

        public int SurroundingMineCount { set; get; }

        public TileStatus Status
        {
            set
            {
                if (tileStatus != value)
                {
                    tileStatus = value;

                    switch (tileStatus)
                    {
                        case TileStatus.Hidden:
                            Content = null;

                            break;

                        case TileStatus.Flagged:
                            Content = flagImage;
                            break;

                        case TileStatus.Exposed:
                            if (IsMine)
                            {
                                Content = mineImage;
                            }
                            else
                            {
                                Content = label;
                                label.Text =
                                        SurroundingMineCount > 0 ?
                                            SurroundingMineCount.ToString() : " ";
                            }
                            break;
                    }

                    if (!doNotFireEvent && TileStatusChanged != null)
                    {
                        TileStatusChanged(this, tileStatus);
                    }
                }
            }
            get
            {
                return tileStatus;
            }
        }

        // Does not fire TileStatusChanged events.
        public void Initialize()
        {
            doNotFireEvent = true;
            Status = TileStatus.Hidden;
            IsMine = false;
            SurroundingMineCount = 0;
            doNotFireEvent = false;
        }

        void OnSingleTap(object sender, object args)
        {

            switch (Status)
            {
                //If unflagged, flag it
                case TileStatus.Hidden:
                    Status = TileStatus.Flagged;
                    break;
                //if flagged, unflag it
                case TileStatus.Flagged:
                    Status = TileStatus.Hidden;
                    break;
                //If exposed, do nothing
                case TileStatus.Exposed:
                    break;
            }
        }

        void OnDoubleTap(object sender, object args)
        {
            Status = TileStatus.Exposed;
        }
    }
}
