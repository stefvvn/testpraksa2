using Facebook.Business;
using Facebook.Entities;
using Facebook.Data.EntityFramework;

namespace Facebook.UI.Winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            List<AccountUserInfoEntities> list = new List<AccountUserInfoEntities>();
            AccountUserInfoBsn bsn = new AccountUserInfoBsn();
            list = bsn.GetUserList();
            LstUsers.ValueMember = "UserIdNumber";
            LstUsers.DisplayMember = "UserName";
            LstUsers.DataSource = list;

            //List<AccountUserInfoEntities> list = new List<AccountUserInfoEntities>();
            //ApplicationDbContext Db = new ApplicationDbContext();
            //list = Db.User.ToList();
            //LstUsers.ValueMember = "UserIdNumber";
            //LstUsers.DisplayMember = "UserName";
            //LstUsers.DataSource = list;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();    
            frm.ShowDialog();
        }

        //POSTS
        private void ShowPosts(int id)
        {
            List<PostEntities> list = new List<PostEntities>();
            PostBsn bsn = new PostBsn();
            list = bsn.GetPostsByUser(id);
            LstPosts.ValueMember = "PostId";
            LstPosts.DisplayMember = "Content";
            LstPosts.DataSource = list;

            //List<PostEntities> list = new List<PostEntities>();
            //ApplicationDbContext Db = new ApplicationDbContext();
            //list = (List<PostEntities>)Db.Post.Where(u => u.UserId == id);
            //LstPosts.ValueMember = "PostId";
            //LstPosts.DisplayMember = "Content";
            //LstPosts.DataSource = list;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            ShowPosts(int.Parse(textBox1.Text));
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            object SelectedUser = LstUsers.SelectedValue;
            ShowPosts(Convert.ToInt32(SelectedUser));
        }

        //COMMENTS
        private void ShowComments(int id)
        {
            List<CommentEntities> list = new List<CommentEntities>();
            CommentBsn bsn = new CommentBsn();
            list = bsn.GetCommentsByPost(id);
            LstComments.ValueMember = "CommentId";
            LstComments.DisplayMember = "Content";
            LstComments.DataSource = list;
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            object SelectedPost = LstPosts.SelectedValue;
            ShowComments(Convert.ToInt32(SelectedPost));
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ShowComments(int.Parse(textBox2.Text));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}