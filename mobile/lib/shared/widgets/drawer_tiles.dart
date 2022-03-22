import 'package:flutter/material.dart';

class DrawerTiles extends StatelessWidget {
  final IconData icon;
  final String text;
  const DrawerTiles({Key? key, required this.icon, required this.text})
      : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 30, vertical: 10),
      child: Row(
        children: [
          Padding(
            padding: const EdgeInsets.only(right: 10),
            child: Icon(icon),
          ),
          Text(text),
        ],
      ),
    );
  }
}
