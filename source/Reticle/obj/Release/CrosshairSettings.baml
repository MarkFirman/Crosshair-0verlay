   M S B A M L   `   `   `  ���� K  GCrosshairOverlay, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ReticleReticle      Reticle.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:Reticle     -     � Title$  Crosshair 0verlay��$	��365��$	��400�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=�.��� .+��  � RowDefinitions �� $	��270 ��� $��60 �.+��  � ColumnDefinitions �� $	��200 ��� $��* �.+�� $��0��$��0��$��	15,10,0,0q� �� $��30 ��� $	��100 ��� $��40 ��� $��20 ��� $��40 ��� $��50 � �� $	��150 �.+��� $��0��$��0��$��15(�$
��Bold"�	CROSSHAIR�� $��1��$��0��
���   �$��2q�._��� -   $��ReticleImagePreview���� -   $��0��$��2��$��0,10,0,0q�.��Choose Image...�� $��3��$��0��$��12(�$��0,2,0,0q�$��Normal"�$��Italic$�	Presets�� -   $��PresetPanel��$��0��$��4�� �� Orientation$ 
Horizontal=�$��Center=�.+��� 
�������$��2q�
 � Tag$ 1��._��� -   $��30��$ 1��.��1�� 
�������$��2q�$��	4.5,0,0,0q�$ 2��._��� -   $��30��$ 2��.��2�� 
�������$��2q�$��	4.5,0,0,0q�$ 3��._��� -   $��30��$ 3��.��3�� 
�������$��2q�$��	4.5,0,0,0q�$ 4��._��� -   $��30��$ 4��.��4�� $��0��$��5��$ 
Horizontal=�.+��� -	   $��AlwaysOnTopCheckbox�� d� 	IsChecked$
 TrueY�$��0,10,0,0q��� $��6,9,0,0q�Always on top?� $��1�� �� $��26 ��� $��20 ��� $��35 �.+��� $��0��$��15(�$��0,10,0,0q�$
��Bold"�	HOTKEYS�� $��1��$��12(�$��0,0,0,0q�$��Normal"�$��Italic$�Toggle Reticle ON/OFF�� -
   $��HotKeyToggleButton��$��3��$��40��$��0,0,0,0q�$
��Left=�.��#�� -   $��StartCrosshairButton��$��Bottom=�$
��Bold"�$��1��$��30��$��15q�$	��350��.��START CROSSHAIR OVERLAY