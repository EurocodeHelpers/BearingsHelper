using BearingsHelper.Classes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearingsHelper.FluentValidation
{
    public class BearingDesignDisplacementsValidator : AbstractValidator<BearingDesignDisplacements>
    {
        public BearingDesignDisplacementsValidator()
        {
            RuleFor(p => p.Tmax)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .GreaterThan(0).WithMessage("{PropertyName} should not be <=0." + PleaseCheckInputAndTryAgain)
                .LessThan(40).WithMessage("Unusually high value of {PropertyName} specified." + PleaseCheckInputAndTryAgain);

            RuleFor(p => p.Tmin)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .LessThan(0).WithMessage("{PropertyName} should not be >=0." + PleaseCheckInputAndTryAgain)
                .GreaterThanOrEqualTo(-25).WithMessage("Unusually low value of {PropertyName} specified." + PleaseCheckInputAndTryAgain);

            RuleFor(p => p.T0)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .GreaterThan(0).WithMessage("{PropertyName} should not be <= 0." + PleaseCheckInputAndTryAgain)
                .LessThanOrEqualTo(20).WithMessage("Unusually high value of {PropertyName} specified (>20)." + PleaseCheckInputAndTryAgain);

            RuleFor(p => p.Altitude)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} should not be <= 0." + PleaseCheckInputAndTryAgain)
                .LessThan(900).WithMessage("Unusually high value of {PropertyName} specified." + PleaseCheckInputAndTryAgain);

            RuleFor(p => p.SurfacingThickness)
                 .InclusiveBetween(0, 200).WithMessage("Surfacing thickness must be greater than 0 and less than 200." + PleaseCheckInputAndTryAgain);

            RuleFor(p => p.L)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .GreaterThan(5).WithMessage("Dist. to fixed bearing should not be <= 0." + PleaseCheckInputAndTryAgain)
                .LessThanOrEqualTo(300*1000).WithMessage("Unusually high value of Dist. to fixed bearing specified." + PleaseCheckInputIsInMetresAndTryAgain);
        }

        private string PleaseCheckInputAndTryAgain => " Please check input and try again.";
        private string PleaseCheckInputIsInMetresAndTryAgain => " Please check input is in metres and try again.";
    }
}
