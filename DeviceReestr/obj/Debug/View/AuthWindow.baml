   M S B A M L   `   `   `  ����G  CDeviceReestr, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:DeviceReestr.ViewDeviceReestr.View  5   	   "    DeviceReestr.View.AuthWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:DeviceReestr.View     5   	     � Title$D  >Реестр оборудования - Авторизация��5      $	��300��62   $	��300��6?    � 
ResizeMode$ NoResize=�6K    � WindowStartupLocation$ CenterScreen=�6a   .��5	      �� $��Center=�6   $��30q�6,   .+�5
   
   �� $��
Логин��6   �� 5   
   ��6   �� *Login+�� 5   
   $��Пароль��6   $��	0 20 10 0q�6#   G� 5   
   -   5        $��PasswordBox��5      �� 5   
   $��	0 20 10 0q�5      $��Center=�5      
���  ��$
��Bold"�5   %   ��5      �� *Info+5   %   �� 5   
   $��
Войти��6    �� 	IsDefault .    DefaultButtonStyle#��[  5      $��
30 30 30 0q�6=   $��5q�6Q   ��5      �� *AuthCommand+��61   ��  �� ElementName$ PasswordBox��5   Q   5      5      