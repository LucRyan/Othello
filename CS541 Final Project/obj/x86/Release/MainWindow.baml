   M S B A M L   `   `   `  ����   CS541 Final Project$    CS541_Final_Project.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Gdxca6http://schemas.devexpress.com/winfx/2008/xaml/carousel     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     �Name$  window�� � Title$ 
MainWindow��$	��757��$
��1122�� � WindowStyle$
 None=� � AllowsTransparency . ��Z� .��� -    �Name$ MainGrid��$	��720��$
��1114��$
��Left=�$	��Top=� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� �� �� T� ����  �� ImageSource$ Images/PSV-bg.jpg��.+��� $��5�����	#4D000000�� $��30��$��249.442,4,180.558,0q�$
��Wrap=�$	��Top=�$��26.667(�$
��Bold"���  � Language$ zh-cn�$H�BA        B        C        D        E         F         G        H���� $
��Left=�$��171.302,55,0,26.674q�$
��Wrap=�$��32.093��$
��Bold"�$��32(��� $ zh-cn�$�1���� �� $ zh-cn��� �� $ zh-cn�$�2���� �� $ zh-cn��� �� $ zh-cn�$�3���� �� $ zh-cn��� �� $ zh-cn�$�4���� �� $ zh-cn��� �� $ zh-cn�$�5���� �� $ zh-cn��� �� $ zh-cn�$�6���� �� $ zh-cn��� �� $ zh-cn�$�7���� �� $ zh-cn��� �� $ zh-cn�$�8���� -    ��Name$ button1��$��
ChessBoard��$��23��$
��Left=�$��	22,32,0,0q�$	��Top=�$��75��$y�	Collapsed=��� -   $ button2��$��	Add Black��$��23��$
��Left=�$��	22,76,0,0q�$	��Top=�$��75��$y�	Collapsed=�A� -   	 A�Name$	 
chessBoard��$	��Top=�$
��Left=�$	��674��$	��674��$��203.395,38,0,0q����� $; 5/CS541%20Final%20Project;component/Images/GreenBG.JPG��
 J� Effect
 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 60Q�   ShadowDepth$ 3Q�   	Direction$	 360Q�� -   $ grid1��$	��674��$	��674��$��203.395,38,0,0q�$
��Left=�$	��Top=���Z� .+��� $��5��
���   ��� -   $ button3��$��	Add White��$��23��$
��Left=�$��
22,130,0,0q�$	��Top=�$��75��$y�	Collapsed=��� -    ��Name$ 	checkBox1��$��
ShowShadow��$��16��$
��Left=�$��	22,60,0,0q�$	��Top=�$	��101���� -	   $ button4��$��Reset��$��23��$
��Left=�$��	22,32,0,0q�$	��Top=�$��75���� -
   $ button5��$��GetAvailable��$��23��$
��Left=�$��
28,302,0,0q�$	��Top=�$��75��$y�	Collapsed=�	� -    	�Name$ radioButton1��$��White��$��16��$
��Left=�$��946,100,0,0q�$	��Top=�$y�	Collapsed=�	� -   $ radioButton2��$��Black��$��16��$
��Left=�$��946,137,0,0q�$	��Top=�$y�	Collapsed=��� -    ��Name$ textBox2��$��23��$��928,235,115,0q�$	��Top=�$y�	Collapsed=�9� $��Control Panel��$��Right=�$��0,8,8,0q�$��223.07��$��239.326��$	��Top=�.��� .+�� $��22.454,0,15.5,130.576q�$��82��$��Bottom=�.+��� ���	#8D60B7E2
�������$��3��$��-19.953,0,-13.814,0q��� -   $ textBox1��$��23��$��15.116,13,12,0q�$	��Top=��� -   $ button6��$	��Add��$��23��$
��Left=�$��15.116,0,0,17q�$��Bottom=�$��75��� $	��103��$��17.118,0,3.952,16.004q�$��Bottom=�.+��� ���	#8D60B7E2
�������$��3��$��-13.814,0,-1.535,-12.279q��� -   $ textBox3��$��23��$
��Left=�$��68,6,0,0q�$	��Top=�$	��120���� -    ��Name$ label1��$��
Ip Address��$��28��$
��Left=�$��0,4,0,0q�$	��Top=��� -   $ button7��$��Connect��$��23��$
��Left=�$��0,80,0,0q�$	��Top=�$��75���� -   $ button8��$��Wait for connection��$��23��$
��Left=�$��	81,80,0,0q�$	��Top=�$	��115���� -   $ textBox4��$��23��$��
68,38,12,0q�$	��Top=��� -   $ label2��$
��Port��$��28��$
��Left=�$��0,33,0,0q�$	��Top=�$��66��