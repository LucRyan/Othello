   M S B A M L   `   `   `  ����   CS541 Final Project     CS541_Final_Project.Splash   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Splash��$	��440��$	��370�� � AllowsTransparency .  � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=���Z�  � 	Resources    
StartAnime �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value��%  &	        �� .��U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ 	textBlock��.\�  $ 0��$ 0Q�  $ 0:0:0.5��$
 -263Q�  $ 0:0:0.6��$
 -268Q�  $ 0:0:0.7��$
 -264Q�  $ 0:0:0.8��$
 -259Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ 
textBlock1��.\�  $ 0��$ 0Q�  $ 0:0:0.8��$ 87Q�  $ 0:0:1.1��$	 273Q�  $ 0:0:1.2��$	 278Q�  $ 0:0:1.3��$	 271Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ 
textBlock2��.\�  $ 0��$ 0Q�  $ 0:0:0.8��$	 -53Q�  $ 0:0:1.1��$
 -248Q�  $ 0:0:1.2��$
 -253Q�  $ 0:0:1.4��$
 -249Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ 
textBlock3��.\�  $ 0��$ 0Q�  $ 0:0:0.8��$ 45Q�  $ 0:0:1.1��$	 267Q�  $ 0:0:1.2��$	 278Q�  $ 0:0:1.3��$	 273Q�  $ 0:0:1.4��$	 266Q�	 � Triggers	 :� 
 :� RoutedEvent$
 FrameworkElement.Loaded��.[��� #��[  .��� -   $	��352��$	��416��.+���  �� RadiusY$	 8.5�� �� RadiusX$	 8.5�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect  ����  �� ImageSource$ Images/StarScreen.png���� -    ��Name$ 	textBlock��$��0,135,-223,0q�$
��Wrap=�$��STHupo)�$��48(�$
��Bold"�$��Right=�$��46��$	��Top=�$	��209�� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� �� �� T� ��  � Language$ zh-cn�$�Reversi���� -   $ 
textBlock1��$
��Left=�$��31��$��-163,0,0,106q�$
��Wrap=�$��Bottom=�$	��144��$��21.333(�$��Segoe WP Black)�$��Italic$�$ 0.5,0.5&�z�V� .~��� �� �� T� �� $ zh-cn�$�Yizhe Chang���� -   $ 
textBlock2��$��Right=�$��31��$��0,0,-158,71q�$
��Wrap=�$��Bottom=�$	��144��$��21.333(�$��Segoe WP Black)�$��Italic$�$ 0.5,0.5&�z�V� .~��� �� �� T� �� $ zh-cn�$�	Yang Wang���� -   $ 
textBlock3��$
��Left=�$��31��$��-163,0,0,34q�$
��Wrap=�$��Bottom=�$	��144��$��21.333(�$��Segoe WP Black)�$��Italic$�$ 0.5,0.5&�z�V� .~��� �� �� T� �� $ zh-cn�$�Peizhu Zhang��