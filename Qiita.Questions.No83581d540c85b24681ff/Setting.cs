using Prism.Mvvm;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qiita.Questions.No83581d540c85b24681ff
{
    public class Setting : BindableBase
    {
        public ReactivePropertySlim<int> Width { get; } = new ReactivePropertySlim<int>();
        public ReactiveProperty<int> Height { get; } = new ReactiveProperty<int>();
    }
}
