using Filerenamer;

namespace FFmpegWin
{
    public partial class frmRename : Form
    {
        public frmRename()
        {
            InitializeComponent();
        }

        private void frmRename_Load(object sender, EventArgs e)
        {

        }

        private void btnRename_Click(object sender, EventArgs e)
        {

            Environment.CurrentDirectory = txtPath.Text;


            var files = Directory.GetFiles(Environment.CurrentDirectory).Where(p=>p.EndsWith(".jpg")|| p.EndsWith(".png")|| p.EndsWith(".bmp")||p.EndsWith(".jpeg")).ToList();            
            ////Rename1(files);
           RenameHelper.Rename2(files);
        }
    }
}
