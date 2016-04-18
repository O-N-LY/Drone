namespace Controller
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnimg = new System.Windows.Forms.Button();
            this.btnrange = new System.Windows.Forms.Button();
            this.btnscan = new System.Windows.Forms.Button();
            this.btnpath = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.videoSourcePlayer = new AForge.Controls.VideoSourcePlayer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.StatePane = new System.Windows.Forms.Panel();
            this.label_other = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label_horizon = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label_battery = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label_direction = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label_hight = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label_speed = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_latitude = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_longitude = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabmain = new System.Windows.Forms.TabPage();
            this.tabcamera = new System.Windows.Forms.TabPage();
            this.btnrecord = new System.Windows.Forms.Button();
            this.btnconnect = new System.Windows.Forms.Button();
            this.combobox_cam = new System.Windows.Forms.ComboBox();
            this.tabcontrol = new System.Windows.Forms.TabPage();
            this.btnback = new System.Windows.Forms.Button();
            this.btnnext = new System.Windows.Forms.Button();
            this.btnlaunch = new System.Windows.Forms.Button();
            this.tabmap = new System.Windows.Forms.TabPage();
            this.mouse_lng = new System.Windows.Forms.Label();
            this.mouse_lat = new System.Windows.Forms.Label();
            this.btn_cache = new System.Windows.Forms.Button();
            this.mapprovider = new System.Windows.Forms.ComboBox();
            this.btncenter = new System.Windows.Forms.Button();
            this.btnclear = new System.Windows.Forms.Button();
            this.tabtest = new System.Windows.Forms.TabPage();
            this.btnreconnect = new System.Windows.Forms.Button();
            this.btntest1 = new System.Windows.Forms.Button();
            this.label_stopwatch = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.StatePane.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabmain.SuspendLayout();
            this.tabcamera.SuspendLayout();
            this.tabcontrol.SuspendLayout();
            this.tabmap.SuspendLayout();
            this.tabtest.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnimg
            // 
            this.btnimg.Location = new System.Drawing.Point(3, 6);
            this.btnimg.Name = "btnimg";
            this.btnimg.Size = new System.Drawing.Size(75, 23);
            this.btnimg.TabIndex = 0;
            this.btnimg.Text = " 物体图片";
            this.btnimg.UseVisualStyleBackColor = true;
            this.btnimg.Click += new System.EventHandler(this.btnimg_Click);
            // 
            // btnrange
            // 
            this.btnrange.Location = new System.Drawing.Point(84, 6);
            this.btnrange.Name = "btnrange";
            this.btnrange.Size = new System.Drawing.Size(75, 23);
            this.btnrange.TabIndex = 1;
            this.btnrange.Text = " 范围";
            this.btnrange.UseVisualStyleBackColor = true;
            this.btnrange.Click += new System.EventHandler(this.btnrange_Click);
            // 
            // btnscan
            // 
            this.btnscan.Location = new System.Drawing.Point(249, 6);
            this.btnscan.Name = "btnscan";
            this.btnscan.Size = new System.Drawing.Size(75, 23);
            this.btnscan.TabIndex = 2;
            this.btnscan.Text = " 寻物开始";
            this.btnscan.UseVisualStyleBackColor = true;
            this.btnscan.Click += new System.EventHandler(this.btnscan_Click);
            // 
            // btnpath
            // 
            this.btnpath.Location = new System.Drawing.Point(165, 6);
            this.btnpath.Name = "btnpath";
            this.btnpath.Size = new System.Drawing.Size(75, 23);
            this.btnpath.TabIndex = 3;
            this.btnpath.Text = " 路径规划";
            this.btnpath.UseVisualStyleBackColor = true;
            this.btnpath.Click += new System.EventHandler(this.btnpath_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.videoSourcePlayer);
            this.groupBox1.Location = new System.Drawing.Point(447, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 184);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "摄像机";
            // 
            // videoSourcePlayer
            // 
            this.videoSourcePlayer.Location = new System.Drawing.Point(6, 20);
            this.videoSourcePlayer.Name = "videoSourcePlayer";
            this.videoSourcePlayer.Size = new System.Drawing.Size(177, 158);
            this.videoSourcePlayer.TabIndex = 0;
            this.videoSourcePlayer.Text = "videoSourcePlayer";
            this.videoSourcePlayer.VideoSource = null;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.StatePane);
            this.groupBox2.Location = new System.Drawing.Point(661, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(155, 184);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "无人机状态";
            // 
            // StatePane
            // 
            this.StatePane.AutoScroll = true;
            this.StatePane.Controls.Add(this.label_other);
            this.StatePane.Controls.Add(this.label16);
            this.StatePane.Controls.Add(this.label_horizon);
            this.StatePane.Controls.Add(this.label14);
            this.StatePane.Controls.Add(this.label_battery);
            this.StatePane.Controls.Add(this.label12);
            this.StatePane.Controls.Add(this.label_direction);
            this.StatePane.Controls.Add(this.label10);
            this.StatePane.Controls.Add(this.label_hight);
            this.StatePane.Controls.Add(this.label8);
            this.StatePane.Controls.Add(this.label_speed);
            this.StatePane.Controls.Add(this.label6);
            this.StatePane.Controls.Add(this.label_latitude);
            this.StatePane.Controls.Add(this.label4);
            this.StatePane.Controls.Add(this.label_longitude);
            this.StatePane.Controls.Add(this.label1);
            this.StatePane.Location = new System.Drawing.Point(6, 20);
            this.StatePane.Name = "StatePane";
            this.StatePane.Size = new System.Drawing.Size(143, 158);
            this.StatePane.TabIndex = 0;
            // 
            // label_other
            // 
            this.label_other.AutoSize = true;
            this.label_other.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_other.Location = new System.Drawing.Point(73, 144);
            this.label_other.Name = "label_other";
            this.label_other.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label_other.Size = new System.Drawing.Size(15, 20);
            this.label_other.TabIndex = 15;
            this.label_other.Text = " ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(4, 144);
            this.label16.Name = "label16";
            this.label16.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label16.Size = new System.Drawing.Size(23, 20);
            this.label16.TabIndex = 14;
            this.label16.Text = "  ";
            // 
            // label_horizon
            // 
            this.label_horizon.AutoSize = true;
            this.label_horizon.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_horizon.Location = new System.Drawing.Point(72, 124);
            this.label_horizon.Name = "label_horizon";
            this.label_horizon.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label_horizon.Size = new System.Drawing.Size(15, 20);
            this.label_horizon.TabIndex = 13;
            this.label_horizon.Text = " ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(3, 124);
            this.label14.Name = "label14";
            this.label14.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label14.Size = new System.Drawing.Size(23, 20);
            this.label14.TabIndex = 12;
            this.label14.Text = "  ";
            // 
            // label_battery
            // 
            this.label_battery.AutoSize = true;
            this.label_battery.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_battery.Location = new System.Drawing.Point(73, 104);
            this.label_battery.Name = "label_battery";
            this.label_battery.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label_battery.Size = new System.Drawing.Size(15, 20);
            this.label_battery.TabIndex = 11;
            this.label_battery.Text = " ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(4, 104);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label12.Size = new System.Drawing.Size(60, 20);
            this.label12.TabIndex = 10;
            this.label12.Text = " 电量：";
            // 
            // label_direction
            // 
            this.label_direction.AutoSize = true;
            this.label_direction.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_direction.Location = new System.Drawing.Point(73, 84);
            this.label_direction.Name = "label_direction";
            this.label_direction.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label_direction.Size = new System.Drawing.Size(15, 20);
            this.label_direction.TabIndex = 9;
            this.label_direction.Text = " ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(4, 84);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label10.Size = new System.Drawing.Size(15, 20);
            this.label10.TabIndex = 8;
            this.label10.Text = " ";
            // 
            // label_hight
            // 
            this.label_hight.AutoSize = true;
            this.label_hight.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_hight.Location = new System.Drawing.Point(73, 64);
            this.label_hight.Name = "label_hight";
            this.label_hight.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label_hight.Size = new System.Drawing.Size(15, 20);
            this.label_hight.TabIndex = 7;
            this.label_hight.Text = " ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(4, 64);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label8.Size = new System.Drawing.Size(60, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = " 高度：";
            // 
            // label_speed
            // 
            this.label_speed.AutoSize = true;
            this.label_speed.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_speed.Location = new System.Drawing.Point(73, 44);
            this.label_speed.Name = "label_speed";
            this.label_speed.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label_speed.Size = new System.Drawing.Size(15, 20);
            this.label_speed.TabIndex = 5;
            this.label_speed.Text = " ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(4, 44);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label6.Size = new System.Drawing.Size(60, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = " 速度：";
            // 
            // label_latitude
            // 
            this.label_latitude.AutoSize = true;
            this.label_latitude.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_latitude.Location = new System.Drawing.Point(73, 24);
            this.label_latitude.Name = "label_latitude";
            this.label_latitude.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label_latitude.Size = new System.Drawing.Size(15, 20);
            this.label_latitude.TabIndex = 3;
            this.label_latitude.Text = " ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(4, 24);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = " 纬度：";
            // 
            // label_longitude
            // 
            this.label_longitude.AutoSize = true;
            this.label_longitude.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_longitude.Location = new System.Drawing.Point(73, 4);
            this.label_longitude.Name = "label_longitude";
            this.label_longitude.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label_longitude.Size = new System.Drawing.Size(15, 20);
            this.label_longitude.TabIndex = 1;
            this.label_longitude.Text = " ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = " 经度：";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(447, 213);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(369, 186);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "结果";
            // 
            // gmap
            // 
            this.gmap.Bearing = 0F;
            this.gmap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gmap.CanDragMap = true;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemmory = 5;
            this.gmap.Location = new System.Drawing.Point(12, 12);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 20;
            this.gmap.MinZoom = 2;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(416, 320);
            this.gmap.TabIndex = 1;
            this.gmap.Zoom = 0D;
            this.gmap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.gmap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this.gmap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabmain);
            this.tabControl1.Controls.Add(this.tabcamera);
            this.tabControl1.Controls.Add(this.tabcontrol);
            this.tabControl1.Controls.Add(this.tabmap);
            this.tabControl1.Controls.Add(this.tabtest);
            this.tabControl1.Location = new System.Drawing.Point(12, 338);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(420, 61);
            this.tabControl1.TabIndex = 7;
            // 
            // tabmain
            // 
            this.tabmain.Controls.Add(this.label_stopwatch);
            this.tabmain.Controls.Add(this.btnscan);
            this.tabmain.Controls.Add(this.btnrange);
            this.tabmain.Controls.Add(this.btnpath);
            this.tabmain.Controls.Add(this.btnimg);
            this.tabmain.Location = new System.Drawing.Point(4, 22);
            this.tabmain.Name = "tabmain";
            this.tabmain.Padding = new System.Windows.Forms.Padding(3);
            this.tabmain.Size = new System.Drawing.Size(412, 35);
            this.tabmain.TabIndex = 0;
            this.tabmain.Text = "功能";
            this.tabmain.UseVisualStyleBackColor = true;
            // 
            // tabcamera
            // 
            this.tabcamera.Controls.Add(this.btnrecord);
            this.tabcamera.Controls.Add(this.btnconnect);
            this.tabcamera.Controls.Add(this.combobox_cam);
            this.tabcamera.Location = new System.Drawing.Point(4, 22);
            this.tabcamera.Name = "tabcamera";
            this.tabcamera.Padding = new System.Windows.Forms.Padding(3);
            this.tabcamera.Size = new System.Drawing.Size(412, 35);
            this.tabcamera.TabIndex = 1;
            this.tabcamera.Text = " 摄像机";
            this.tabcamera.UseVisualStyleBackColor = true;
            // 
            // btnrecord
            // 
            this.btnrecord.Location = new System.Drawing.Point(215, 6);
            this.btnrecord.Name = "btnrecord";
            this.btnrecord.Size = new System.Drawing.Size(75, 23);
            this.btnrecord.TabIndex = 2;
            this.btnrecord.Text = "开始录制";
            this.btnrecord.UseVisualStyleBackColor = true;
            this.btnrecord.Click += new System.EventHandler(this.btnrecord_Click);
            // 
            // btnconnect
            // 
            this.btnconnect.Location = new System.Drawing.Point(133, 6);
            this.btnconnect.Name = "btnconnect";
            this.btnconnect.Size = new System.Drawing.Size(75, 23);
            this.btnconnect.TabIndex = 1;
            this.btnconnect.Text = "连接";
            this.btnconnect.UseVisualStyleBackColor = true;
            this.btnconnect.Click += new System.EventHandler(this.btnconnect_Click);
            // 
            // combobox_cam
            // 
            this.combobox_cam.FormattingEnabled = true;
            this.combobox_cam.Location = new System.Drawing.Point(6, 6);
            this.combobox_cam.Name = "combobox_cam";
            this.combobox_cam.Size = new System.Drawing.Size(121, 20);
            this.combobox_cam.TabIndex = 0;
            this.combobox_cam.Text = " ";
            this.combobox_cam.SelectedIndexChanged += new System.EventHandler(this.OnCamInputChanged);
            // 
            // tabcontrol
            // 
            this.tabcontrol.Controls.Add(this.btnback);
            this.tabcontrol.Controls.Add(this.btnnext);
            this.tabcontrol.Controls.Add(this.btnlaunch);
            this.tabcontrol.Location = new System.Drawing.Point(4, 22);
            this.tabcontrol.Name = "tabcontrol";
            this.tabcontrol.Size = new System.Drawing.Size(412, 35);
            this.tabcontrol.TabIndex = 2;
            this.tabcontrol.Text = "控制";
            this.tabcontrol.UseVisualStyleBackColor = true;
            // 
            // btnback
            // 
            this.btnback.Location = new System.Drawing.Point(166, 3);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(75, 23);
            this.btnback.TabIndex = 3;
            this.btnback.Text = "回归";
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // btnnext
            // 
            this.btnnext.Location = new System.Drawing.Point(85, 4);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(75, 23);
            this.btnnext.TabIndex = 1;
            this.btnnext.Text = "下一点";
            this.btnnext.UseVisualStyleBackColor = true;
            this.btnnext.Click += new System.EventHandler(this.btnnext_Click);
            // 
            // btnlaunch
            // 
            this.btnlaunch.Location = new System.Drawing.Point(3, 5);
            this.btnlaunch.Name = "btnlaunch";
            this.btnlaunch.Size = new System.Drawing.Size(75, 23);
            this.btnlaunch.TabIndex = 0;
            this.btnlaunch.Text = " 着陆";
            this.btnlaunch.UseVisualStyleBackColor = true;
            this.btnlaunch.Click += new System.EventHandler(this.btnlaunch_Click);
            // 
            // tabmap
            // 
            this.tabmap.Controls.Add(this.mouse_lng);
            this.tabmap.Controls.Add(this.mouse_lat);
            this.tabmap.Controls.Add(this.btn_cache);
            this.tabmap.Controls.Add(this.mapprovider);
            this.tabmap.Controls.Add(this.btncenter);
            this.tabmap.Controls.Add(this.btnclear);
            this.tabmap.Location = new System.Drawing.Point(4, 22);
            this.tabmap.Name = "tabmap";
            this.tabmap.Size = new System.Drawing.Size(412, 35);
            this.tabmap.TabIndex = 3;
            this.tabmap.Text = "地图";
            this.tabmap.UseVisualStyleBackColor = true;
            // 
            // mouse_lng
            // 
            this.mouse_lng.AutoSize = true;
            this.mouse_lng.Location = new System.Drawing.Point(254, 19);
            this.mouse_lng.Name = "mouse_lng";
            this.mouse_lng.Size = new System.Drawing.Size(17, 12);
            this.mouse_lng.TabIndex = 5;
            this.mouse_lng.Text = "--";
            // 
            // mouse_lat
            // 
            this.mouse_lat.AutoSize = true;
            this.mouse_lat.Location = new System.Drawing.Point(254, 5);
            this.mouse_lat.Name = "mouse_lat";
            this.mouse_lat.Size = new System.Drawing.Size(17, 12);
            this.mouse_lat.TabIndex = 4;
            this.mouse_lat.Text = "--";
            // 
            // btn_cache
            // 
            this.btn_cache.Location = new System.Drawing.Point(181, 6);
            this.btn_cache.Name = "btn_cache";
            this.btn_cache.Size = new System.Drawing.Size(52, 23);
            this.btn_cache.TabIndex = 3;
            this.btn_cache.Text = "Cache";
            this.btn_cache.UseVisualStyleBackColor = true;
            this.btn_cache.Click += new System.EventHandler(this.btncache_Click);
            // 
            // mapprovider
            // 
            this.mapprovider.FormattingEnabled = true;
            this.mapprovider.Items.AddRange(new object[] {
            "高德地图",
            "高德卫星"});
            this.mapprovider.Location = new System.Drawing.Point(3, 8);
            this.mapprovider.Name = "mapprovider";
            this.mapprovider.Size = new System.Drawing.Size(79, 20);
            this.mapprovider.TabIndex = 2;
            this.mapprovider.SelectedIndexChanged += new System.EventHandler(this.mapprovider_changed);
            // 
            // btncenter
            // 
            this.btncenter.Location = new System.Drawing.Point(134, 5);
            this.btncenter.Name = "btncenter";
            this.btncenter.Size = new System.Drawing.Size(41, 23);
            this.btncenter.TabIndex = 1;
            this.btncenter.Text = "居中";
            this.btncenter.UseVisualStyleBackColor = true;
            this.btncenter.Click += new System.EventHandler(this.btncenter_Click);
            // 
            // btnclear
            // 
            this.btnclear.Location = new System.Drawing.Point(88, 6);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(40, 23);
            this.btnclear.TabIndex = 0;
            this.btnclear.Text = "清空";
            this.btnclear.UseVisualStyleBackColor = true;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // tabtest
            // 
            this.tabtest.Controls.Add(this.btnreconnect);
            this.tabtest.Controls.Add(this.btntest1);
            this.tabtest.Location = new System.Drawing.Point(4, 22);
            this.tabtest.Name = "tabtest";
            this.tabtest.Size = new System.Drawing.Size(412, 35);
            this.tabtest.TabIndex = 4;
            this.tabtest.Text = " test";
            this.tabtest.UseVisualStyleBackColor = true;
            // 
            // btnreconnect
            // 
            this.btnreconnect.Location = new System.Drawing.Point(13, 5);
            this.btnreconnect.Name = "btnreconnect";
            this.btnreconnect.Size = new System.Drawing.Size(75, 23);
            this.btnreconnect.TabIndex = 1;
            this.btnreconnect.Text = "重连";
            this.btnreconnect.UseVisualStyleBackColor = true;
            this.btnreconnect.Click += new System.EventHandler(this.btnreconnect_Click);
            // 
            // btntest1
            // 
            this.btntest1.Location = new System.Drawing.Point(106, 5);
            this.btntest1.Name = "btntest1";
            this.btntest1.Size = new System.Drawing.Size(75, 23);
            this.btntest1.TabIndex = 0;
            this.btntest1.Text = " test";
            this.btntest1.UseVisualStyleBackColor = true;
            this.btntest1.Click += new System.EventHandler(this.btntest1_Click);
            // 
            // label_stopwatch
            // 
            this.label_stopwatch.AutoSize = true;
            this.label_stopwatch.Location = new System.Drawing.Point(330, 11);
            this.label_stopwatch.Name = "label_stopwatch";
            this.label_stopwatch.Size = new System.Drawing.Size(17, 12);
            this.label_stopwatch.TabIndex = 4;
            this.label_stopwatch.Text = "--";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 400);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gmap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "感认知增强无人机平台";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.Load += new System.EventHandler(this.OnMainform_loaded);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.StatePane.ResumeLayout(false);
            this.StatePane.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabmain.ResumeLayout(false);
            this.tabmain.PerformLayout();
            this.tabcamera.ResumeLayout(false);
            this.tabcontrol.ResumeLayout(false);
            this.tabmap.ResumeLayout(false);
            this.tabmap.PerformLayout();
            this.tabtest.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.Button btnimg;
        private System.Windows.Forms.Button btnrange;
        private System.Windows.Forms.Button btnscan;
        private System.Windows.Forms.Button btnpath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel StatePane;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_battery;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label_direction;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label_hight;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label_speed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_latitude;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_longitude;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabmain;
        private System.Windows.Forms.TabPage tabcamera;
        private System.Windows.Forms.TabPage tabcontrol;
        private System.Windows.Forms.TabPage tabmap;
        private System.Windows.Forms.Button btnrecord;
        private System.Windows.Forms.Button btnconnect;
        private System.Windows.Forms.ComboBox combobox_cam;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Button btnnext;
        private System.Windows.Forms.Button btnlaunch;
        private System.Windows.Forms.Button btncenter;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.TabPage tabtest;
        private System.Windows.Forms.Button btntest1;
        private System.Windows.Forms.Button btnreconnect;
        private System.Windows.Forms.Label label_other;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label_horizon;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox mapprovider;
        private System.Windows.Forms.Button btn_cache;
        private System.Windows.Forms.Label mouse_lat;
        private System.Windows.Forms.Label mouse_lng;
        private System.Windows.Forms.Label label_stopwatch;
    }
}

