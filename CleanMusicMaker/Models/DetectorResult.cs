using CleanMusicMaker.Extensions;

namespace CleanMusicMaker.Models
{
    public class DetectorResult
    {
        public int LineNo { get; }
        public string? Line { get; }

        public string? Issues { get; }

        public string? Area { get; }

        public  DetectorResult(int lineNo, string? line)
        {
            LineNo = lineNo;
            Line = line;
            Issues = "No Issues Found";
            Area = "No Issues Found";
        }

        public DetectorResult(int lineNo, string? line, string? issues, string? area)
        {
            LineNo = lineNo;
            Line = line;
            Issues = issues;
            Area = area;
        }

        public static DetectorResult? Create(int lineNo, DetectorResponse? model)
        {
            if (model == null || model.Data == null || model.Data.Content == null)
                throw new ArgumentNullException(nameof(model));

            if (model.Data.Categories == null || !model.Data.Categories.Any())
                return new DetectorResult(lineNo, model.Data.Content);

            var issues = string.Empty;
            var area = string.Empty;

            foreach (var category in model.Data.Categories)
            {
                issues += category.Label + " <br/>";

                if (category.Positions == null) continue;
                
                foreach (var position in category.Positions)
                {
                    var substr = model.Data.Content.GetSubString(position.Start, position.End);
                    area += model.Data.Content.Replace(substr, $@"<mark>{substr}</mark>") + " <br/>";
                }
            }

            return new DetectorResult(lineNo, model.Data.Content, issues, area);
        }
    }
}
