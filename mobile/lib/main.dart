import 'package:check/modules/block/block_page.dart';
import 'package:check/modules/home/home_page.dart';
import 'package:check/modules/notification/notification_page.dart';
import 'package:check/modules/success/success_page.dart';
import 'package:check/shared/themes/app_colors.dart';
import 'package:flutter/material.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(
        splashColor: AppColors.primary,
        primaryColor: AppColors.primary,
      ),
      home: NotificationPage(),
    );
  }
}
