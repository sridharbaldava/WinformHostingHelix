using HelixToolkit.Wpf;
//using SharpDX;
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
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace WinformHostingHelix
{
    public partial class Form1 : Form
    {
        private ElementHost elementHost;
        private HelixViewport3D viewport3D;
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
            viewport3D = new HelixViewport3D();
            elementHost.Child = viewport3D;
            var b1 = new MeshBuilder();
            b1.AddSphere( new Point3D( 0, 0, 0 ), 0.5 );
            b1.AddBox( new Point3D( 0, 0, 0 ), 1, 0.5, 2, BoxFaces.All );
            MeshGeometry3D model = b1.ToMesh();
            var modelVisual = new ModelVisual3D();
            modelVisual.Children.Add( new MeshGeometryVisual3D { MeshGeometry = model, Material = MaterialHelper.CreateMaterial(Colors.Green) } );
            viewport3D.Children.Add( modelVisual );
            viewport3D.Children.Add( new SunLight() );           
        }
    }
}
