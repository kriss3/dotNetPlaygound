using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppStrategyPattern;
public interface IExportSvc
{
	void Export(Order order);
}

public record Order();
