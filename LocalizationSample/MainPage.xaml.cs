﻿using LocalizationSample.Resources.Localization;
using System.Globalization;

namespace LocalizationSample
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        public LocalizationResourceManager LocalizationResourceManager { get; }
        public MainPage()
        {
            InitializeComponent();
            LocalizationResourceManager = LocalizationResourceManager.Instance;
            lblCodeBehind.SetBinding(Label.TextProperty, new Binding("LocalizationResourceManager[Intro]", BindingMode.OneWay));
            //lblCodeBehind.Text= LocalizationResourceManager.Instance["Intro"].ToString();
            //BindingContext = this;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            CounterBtn.Text = string.Format(LocalizationResourceManager.Instance["ClickMe"].ToString(), count.ToString());
            //if (count == 1)
            //    CounterBtn.Text = $"Clicked {count} time";
            //else
            //    CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void pickerLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocalizationResourceManager.Instance.SetCulture(new CultureInfo(pickerLang.Items[pickerLang.SelectedIndex]));
            lblCodeBehind.Text = LocalizationResourceManager.Instance["Intro"].ToString();
        }
    }
}