using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Halloumi.Abettor.Controllers
{
    public partial class AbettorController : Component
    {
        #region Private Variables

        /// <summary>
        /// The number of values to keep in the value history
        /// </summary>
        private const int _iconSize = 16;

        /// <summary>
        /// A history of the values of the cpu counter
        /// </summary>
        private int[] _cpuIconValues = new int[_iconSize];

        /// <summary>
        /// A history of the values of the ram counter
        /// </summary>
        private int[] _ramIconValues = new int[_iconSize];

        #endregion

        #region Contructors
        
        /// <summary>
        /// Initializes a new instance of the Monitor class.
        /// </summary>
        public AbettorController()
        {
            InitializeComponent();
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the Monitor class.
        /// </summary>
        public AbettorController(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the Monitor class.
        /// </summary>
        private void Initialize()
        {
            InitializeIconValues(ref _cpuIconValues);
            InitializeIconValues(ref _ramIconValues);
            HighCPUColour = Color.White;
            LowCPUColour = Color.MediumBlue;
            BackColour = Color.Black;
            RAMColour = Color.DarkGray;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the gradient color when a CPU histogram bar is at the maximum value
        /// </summary>
        public Color HighCPUColour
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the gradient color when a CPU histogram bar is at the minimum value
        /// </summary>
        public Color LowCPUColour
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the background colour
        /// </summary>
        public Color BackColour
        {
            get ; set; 
        }

        /// <summary>
        /// Gets or sets the memory line colour
        /// </summary>
        public Color RAMColour
        {
            get;
            set;
        }

        /// <summary>
        /// Gets most recent value from the main counter.
        /// </summary>
        public float CPUValue
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the most recent value from the secondary counter
        /// </summary>
        public float RAMValue
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a description the most recent state of the main and secondary counters.
        /// </summary>
        public string Text
        {
            get 
            {
                return "CPU: "
                    + CPUValue.ToString("0")
                    + "%  RAM: "
                    + RAMValue.ToString("0")
                    + "%";
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Retreives the current values from the performance counters
        /// </summary>
        public void UpdateValues()
        {
            if (cpuCounter != null)
            {
                // get current value from cpu counter
                //CPUValue = cpuCounter.NextValue();
                //CPUValue = cpuCounter.NextValue() / Environment.ProcessorCount;
                CPUValue = GetAverageCPU();

                AddToIconValues(CPUValue, ref _cpuIconValues);
            }

            if (ramCounter != null)
            {
                // get current value from ram counter
                RAMValue = ramCounter.NextValue();

                AddToIconValues(RAMValue, ref _ramIconValues);
            }
        }

        private float GetAverageCPU()
        {
            float processorUtilization = 0;
            var count = 10;
            for (int i = 0; i < count; i++)
            {
                processorUtilization += cpuCounter.NextValue();
            }
                           
            return processorUtilization / count;
        }

        /// <summary>
        /// Generates a histogram bitmap based on the supplied values.
        /// </summary>
        /// <param name="values">The values to base the histogram on. (Each value should be out of 100)</param>
        /// <returns>A bitmap drawing of the histogram</returns>
        public Bitmap GenerateBitmap()
        {
            var bitmap = new Bitmap(_iconSize, _iconSize, PixelFormat.Format32bppRgb);
            using (var g = Graphics.FromImage(bitmap))
            {
                // fill background with cpu gradient
                var rectangle = new Rectangle(0, 0, _iconSize, _iconSize);
                using (Brush brush = new LinearGradientBrush(rectangle,
                    HighCPUColour,
                    LowCPUColour,
                    LinearGradientMode.Vertical))
                {
                    g.FillRectangle(brush, rectangle);
                }

                // draw each bar representing inverse cpu values in black
                Brush backgroundBrush = new SolidBrush(BackColour);
                for (var i = 0; i < _iconSize; i++)
                {
                    g.FillRectangle(backgroundBrush, i, 0, 1, _iconSize - _cpuIconValues[i]);
                }

                // draw the memory line
                var ramPen = new Pen(RAMColour, 1);
                for (var i = 1; i < _iconSize; i++)
                {
                    g.DrawLine(ramPen,
                        i,
                        _iconSize - _ramIconValues[i],
                        i - 1,
                        _iconSize - _ramIconValues[i - 1]);
                }
            }

            return bitmap;
        }

        /// <summary>
        /// Launches the task manager.
        /// </summary>
        public void LaunchTaskManager()
        {
            Process.Start("TaskMgr.exe");
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Initializes the icon values.
        /// </summary>
        private void InitializeIconValues(ref int[] iconValues)
        {
            // clear historic values
            // set historic values to maximum size of 0 values
            for (var i = 0; i < _iconSize; i++)
            {
                iconValues[i] = 0;
            }
        }

        /// <summary>
        /// Converts a percent value to a value out of _iconSize and adds it to the list.
        /// </summary>
        /// <param name="percentValue">The percent value.</param>
        private void AddToIconValues(float percentValue, ref int[] iconValues)
        { 
            var value = (int)((percentValue / 100) * _iconSize);
            if (value > _iconSize)
            {
                value = _iconSize;
            }

            if (value < 0)
            {
                value = 0;
            }

            ShiftIconValuesLeft(ref iconValues);
            iconValues[_iconSize - 1] = value;
        }

        /// <summary>
        /// Shifts the icon values array one element to the left.
        /// </summary>
        private void ShiftIconValuesLeft(ref int[] iconValues)
        {
            for (var i = 0; i < _iconSize - 1; i++)
            {
                iconValues[i] = iconValues[i + 1];
            }    
        }

        #endregion
    }
}
