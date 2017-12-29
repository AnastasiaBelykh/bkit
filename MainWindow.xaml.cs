1. using System;
2. using System.Collections.Generic;
3. using System.ComponentModel;
4. using System.Data;
5. using System.Drawing;
6. using System.Linq;
7. using System.Text;
8. using System.Threading.Tasks;
9. using System.Windows.Forms;
10.using System.IO;
11.using System.Diagnostics;
12.
13.namespace lab4
14.{
15. public partial class Form1 : Form
16. {
17. public Form1()
18. {
19. InitializeComponent();
20. label1.Text = "";
21. label2.Text = "";
22. label3.Text = "";
23. label4.Text = "";
24. }
25. static string GetExecPath()
26. {
27. //Получение пути и имени текущего исполняемого файла
28. //с помощью механизма рефлексии
29. string exeFileName =
System.Reflection.Assembly.GetExecutingAssembly().Location;
30. //Получение пути к текущему исполняемому файлу
31. string Result = Path.GetDirectoryName(exeFileName);
32. return Result;
33. }
34.
35. List<string> list = new List<string>();
36.
37. private void button1_Click(object sender, EventArgs e)
38. {
39.
40. OpenFileDialog fd = new OpenFileDialog();
41. fd.Filter = "текстовые файлы|*.txt";
42. if (fd.ShowDialog() == DialogResult.OK)
43. {
44. Stopwatch t = new Stopwatch();
45. t.Start();
46. char[] separators = new char[] { ' ', '.', ',', '!', '?', '/', '\t', '\n' };
47.
48. string text = File.ReadAllText(fd.FileName);
49. string[] textArray = text.Split(separators);
50. foreach (string strTemp in textArray)
51. {
52. //Удаление пробелов в начале и конце строки
53. string str = strTemp.Trim();
54. //Добавление строки в список, если строка не содержится
в списке
55. if (!list.Contains(str)) list.Add(str);
56. }
57. t.Stop();
58. for (int i = 0; i<list.Count; i++)
59. {
60. listBox1.Items.Add(list[i]);
61. }
62. label1.Text = "Время чтения = " + t.Elapsed.ToString();
63. label2.Text = "Всего элементов = " + list.Count.ToString();
64.
65. }
66. else
67. {
68. MessageBox.Show("Необходимо выбрать файл");
69. }
70. }
71.
72. private void listBox1_SelectedIndexChanged(object sender,
EventArgs e)
73. {
74.
75. }
76.
77. private void label1_Click(object sender, EventArgs e)
78. {
79.
80. }
81.
82. private void Form1_Load(object sender, EventArgs e)
83. {
84.
85. }
86.
87. private void button2_Click(object sender, EventArgs e)
88. {
89. string word = this.textBox1.Text.Trim();
90.
91. //Если слово для поиска не пусто
92. if (!string.IsNullOrWhiteSpace(word) && list.Count > 0)
93. {
94. //Слово для поиска в верхнем регистре
95. string wordUpper = word.ToUpper();
96.
97. //Временные результаты поиска
98. List<string> tempList = new List<string>();
99.
100. Stopwatch t = new Stopwatch();
101. t.Start();
102.
103. foreach (string str in list)
104. {
105. if (str.ToUpper().Contains(wordUpper))
106. {
107. tempList.Add(str);
108. }
109. }
110.
111. t.Stop();
112. label4.Text = "Время поиска = " + t.Elapsed.ToString();
113.
114. this.listBox2.BeginUpdate();
115.
116. //Очистка списка
117. this.listBox2.Items.Clear();
118.
119. //Вывод результатов поиска
120. foreach (string str in tempList)
121. {
    122. this.listBox2.Items.Add(str);
    123. }
124. this.listBox2.EndUpdate();
125. label3.Text = "Найдено элементов = " +
tempList.Count.ToString();
126. }
127. else
128. {
129. MessageBox.Show("Необходимо выбрать файл и ввести
слово для поиска");
130. }
131. }
132.
133. private void textBox1_TextChanged(object sender, EventArgs e)
134. {
135.
136. }
137.
138.
139. }
140. }