namespace WebApplication1.Models
{
    public class StudentInfo
    {
        public Student student { get; set; }
        public Group group1 { get; set; }

        public Group group2 { get; set; }

        public Marks marks1 { get; set; }

        public Marks marks2 { get; set; }

        public float checkInfo(ReportInfo report){
            String tempYear = report.year.ToString();
            String tempGroup = report.group.ToString();
            String month1 = report.month1.ToString();
            String month2 = report.month2.ToString();

            float mark = getMarks(month1, month2, tempYear, tempGroup);
            return mark;
        }

        public float getMarks(String m1, String m2, String year, String tempGroup)
        {
            float sum = 0;
            List<String> list = new List<string>() { "9", "10","11", "12", "1","2", "3","4", "5" };
            int i = 0;
            int j = 0;
            i = list.IndexOf(m1);
            j = list.IndexOf(m2);
            int range = j - i;


            List<String> newList = list.GetRange(i, range + 1);

            //for(int k = 0; )
            //добавить проверку на группу

            List<String> checkedGr = new List<String>();
            checkedGr = checkGroups(newList, tempGroup);
            int len = checkedGr.Count;

            float temp = 0;
            float getMarksFloat = 0;
            foreach (String str in checkedGr)
            {
                if (year == "2020-2021")
                { 
                    getMarksFloat = getMarkMonth1(str);
                }
                if (year == "2021-2022")
                {
                    getMarksFloat = getMarkMonth2(str);
                }
                temp = temp + getMarksFloat;
            }

            float finalFl = 0;
            if (len == 0)
            {
                finalFl = 0;
            }
            else
            {
                finalFl = temp / len;
            }
            
            
            return finalFl;
        }


        public List<string> checkGroups(List<String> newList, String group)
        {
            List<string> temp = new List<String>();
            if ((this.group1.Sp == group) && (newList.Contains("9"))){
                temp.Add("9");
            }
            if ((this.group1.Oct == group) && (newList.Contains("10")))
            {
                temp.Add("10");
            }
            if ((this.group1.Nv == group) && (newList.Contains("11")))
            {
                temp.Add("11");
            }
            if ((this.group1.Dc == group) && (newList.Contains("12")))
            {
                temp.Add("12");
            }
            if ((this.group1.Jn == group) && (newList.Contains("1")))
            {
                temp.Add("1");
            }
            if ((this.group1.Fbr == group) && (newList.Contains("2")))
            {
                temp.Add("2");
            }
            if ((this.group1.Mrch == group) && (newList.Contains("3")))
            {
                temp.Add("3");
            }
            if ((this.group1.Apr == group) && (newList.Contains("4")))
            {
                temp.Add("4");
            }
            if ((this.group1.May == group) && (newList.Contains("5")))
            {
                temp.Add("5");
            }
            return temp;
        }


        public float getMarkMonth1(String monthNumb)
        {
            float temp = 0;
            switch (monthNumb)
            {
                case "9":                
                    temp = float.Parse(this.marks1.Sp);
                    break;
                case "10":
                    temp = float.Parse(this.marks1.Oct);
                    break;
                case "11":
                    temp = float.Parse(this.marks1.Nv);
                    break;
                case "12":
                    temp = float.Parse(this.marks1.Dc);
                    break;
                case "1":
                    temp = float.Parse(this.marks1.Jn);
                    break;
                case "2":
                    temp = float.Parse(this.marks1.Fbr);
                    break;
                case "3":
                    temp = float.Parse(this.marks1.Mrch);
                    break;
                case "4":
                    temp = float.Parse(this.marks1.Apr);
                    break;
                case "5":
                    temp = float.Parse(this.marks1.May);
                    break;
                
            }
            return temp;
        }

        public float getMarkMonth2(String monthNumb)
        {
            float temp = 0;
            switch (monthNumb)
            {
                case "9":
                    temp = float.Parse(this.marks2.Sp);
                    break;
                case "10":
                    temp = float.Parse(this.marks2.Oct);
                    break;
                case "11":
                    temp = float.Parse(this.marks2.Nv);
                    break;
                case "12":
                    temp = float.Parse(this.marks2.Dc);
                    break;
                case "1":
                    temp = float.Parse(this.marks2.Jn);
                    break;
                case "2":
                    temp = float.Parse(this.marks2.Fbr);
                    break;
                case "3":
                    temp = float.Parse(this.marks2.Mrch);
                    break;
                case "4":
                    temp = float.Parse(this.marks2.Apr);
                    break;
                case "5":
                    temp = float.Parse(this.marks2.May);
                    break;

            }
            return temp;
        }

    }
}
