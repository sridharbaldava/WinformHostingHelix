using HelixToolkit.Wpf.SharpDX;
using SharpDX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace WinformHostingHelix
{
    public partial class Form1 : Form
    {
        private ElementHost elementHost;
        private HelixToolkit.Wpf.SharpDX.Viewport3DX viewport3DX;
        public Form1( )
        {
            InitializeComponent( );
        }

        private void Form1_Load( object sender, EventArgs e )
        {
            elementHost = new ElementHost
            {
                Dock = DockStyle.Fill
            };
            panel1.Controls.Add( elementHost );
            viewport3DX = new HelixToolkit.Wpf.SharpDX.Viewport3DX( );
            elementHost.Child = viewport3DX;
            var b1 = new MeshBuilder();
            b1.AddSphere( new Vector3( 0, 0, 0 ), 0.5 );
            b1.AddBox( new Vector3( 0, 0, 0 ), 1, 0.5, 2, BoxFaces.All );
            MeshGeometry3D model = b1.ToMeshGeometry3D();
            MeshGeometryModel3D test = new MeshGeometryModel3D
            {
                Material = PhongMaterials.Gold,
                Geometry = model
            };
            var ambientLight = new AmbientLight3D
            {
                Color = System.Windows.Media.Colors.DimGray
            };
            var directionalLight = new DirectionalLight3D
            {
                Color = System.Windows.Media.Colors.White,
                Direction = new System.Windows.Media.Media3D.Vector3D(-2, -5, -2)
            };
            viewport3DX.Items.Add( ambientLight );
            viewport3DX.Items.Add( directionalLight );
            //test.Attach( viewport3DX );
            viewport3DX.Items.Add( test );
        }
    }
}
