using DevExpress.XtraBars.Ribbon;
using System.ComponentModel;
using System.Drawing;

namespace DevExpress.XtraTabbedMdi
{
    public class XtraTabbedMdiManagerEX : DevExpress.XtraTabbedMdi.XtraTabbedMdiManager
    {
        private Image _backImage = null;
        private Image _BigLogo = null;

        public XtraTabbedMdiManagerEX()
            : base()
        {
        }

        public XtraTabbedMdiManagerEX(IContainer container)
            : base(container)
        {
        }

        [DefaultValue(null)]
        public Image BackImage
        {
            set
            {
                _backImage = value;
            }
            get
            {
                return _backImage;
            }
        }

        [DefaultValue(null)]
        public Image BigLogo
        {
            set
            {
                _BigLogo = value;
            }
            get
            {
                return _BigLogo;
            }
        }

        protected override void OnSelectedPageChanged(object sender, XtraTab.ViewInfo.ViewInfoTabPageChangedEventArgs e)
        {
            base.OnSelectedPageChanged(sender, e);
            if (SelectedPage != null)
            {
                RibbonForm form = this.SelectedPage.MdiChild as RibbonForm;
                RibbonForm formmdi = this.MdiParent as RibbonForm;
                if (form != null && formmdi != null && formmdi.Ribbon != null && form.Ribbon.MergedCategories.TotalCategory.GetFirstVisiblePage() != null)
                {
                    formmdi.Ribbon.SelectedPage = formmdi.Ribbon.MergedCategories.TotalCategory.GetPageByText(form.Ribbon.MergedCategories.TotalCategory.GetFirstVisiblePage().Text);
                }
            }
        }

        protected override void DrawNC(DevExpress.Utils.Drawing.DXPaintEventArgs e)
        {
            if (this.Pages.Count > 0)
            {
                base.DrawNC(e);
            }
            else
            {
                if (_backImage != null)
                    e.Graphics.DrawImage(_backImage, 0, 0, Bounds.Width + 1, Bounds.Height + 1);
                //e.Graphics.DrawImage(_backImage, Bounds.Width - _backImage.Width, Bounds.Height - _backImage.Height);
                if (_BigLogo != null)
                    e.Graphics.DrawImage(_BigLogo, 10, Bounds.Height - _BigLogo.Height - 10);
            }
        }

        private void InitializeComponent()
        {
            //
            // XtraTabbedMdiManagerEX
            //
            this.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.AppearancePage.Header.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.AppearancePage.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.AppearancePage.Header.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.AppearancePage.Header.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.AppearancePage.Header.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.AppearancePage.Header.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.AppearancePage.HeaderActive.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.AppearancePage.HeaderActive.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.AppearancePage.HeaderActive.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.AppearancePage.HeaderActive.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.AppearancePage.HeaderActive.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.AppearancePage.HeaderActive.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.AppearancePage.HeaderDisabled.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.AppearancePage.HeaderDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.AppearancePage.HeaderDisabled.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.AppearancePage.HeaderDisabled.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.AppearancePage.HeaderDisabled.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.AppearancePage.HeaderDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.AppearancePage.HeaderHotTracked.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.AppearancePage.HeaderHotTracked.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.AppearancePage.HeaderHotTracked.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.AppearancePage.HeaderHotTracked.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.AppearancePage.HeaderHotTracked.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.AppearancePage.HeaderHotTracked.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            this.AppearancePage.PageClient.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.AppearancePage.PageClient.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.AppearancePage.PageClient.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Default;
            this.AppearancePage.PageClient.TextOptions.Trimming = DevExpress.Utils.Trimming.Default;
            this.AppearancePage.PageClient.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default;
            this.AppearancePage.PageClient.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Default;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}