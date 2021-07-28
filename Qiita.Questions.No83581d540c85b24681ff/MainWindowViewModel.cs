using Prism.Mvvm;
using Reactive.Bindings;
using System;
using System.Linq;
using System.Reactive.Linq;

namespace Qiita.Questions.No83581d540c85b24681ff
{
    public class MainWindowViewModel : BindableBase
    {
        public ReadOnlyReactivePropertySlim<string> Message { get; }
        public ReactivePropertySlim<Setting> EditTarget { get; } = new ReactivePropertySlim<Setting>();
        public ReactiveCommand OkCommand { get; }

        public ReactiveCommand ChangeEditTargetValueCommand { get; }
        public MainWindowViewModel()
        {
            EditTarget.Value = new Setting();

            OkCommand = EditTarget
                .Select(x => x.Width.CombineLatest(x.Height, (a, b) => a > 0 && b > 0))
                .Switch()
                .ToReactiveCommand();

            // Ok ボタンが押せたら更新されるプロパティを定義しているだけです（動作確認用）
            Message = OkCommand.Select(_ => DateTime.Now.ToString()).ToReadOnlyReactivePropertySlim();

            // EditTarget の値を更新するコマンド
            ChangeEditTargetValueCommand = new ReactiveCommand()
                .WithSubscribe(() => EditTarget.Value = new Setting());
        }
    }
}
