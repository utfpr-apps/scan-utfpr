import 'package:flutter/material.dart';
import 'package:scan/shared/themes/app_colors.dart';

class Button extends StatelessWidget {
  final VoidCallback? onTap;
  final String title;
  const Button({Key? key, this.onTap, required this.title}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return ElevatedButton(
      onPressed: onTap,
      style: ButtonStyle(
          backgroundColor: MaterialStateProperty.all<Color>(AppColors.primary)),
      child: SizedBox(
        child: Text(
          title,
          textAlign: TextAlign.center,
        ),
        width: 300,
      ),
    );
  }
}
