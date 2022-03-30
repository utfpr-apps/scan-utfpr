import 'package:flutter/material.dart';

import '../themes/app_images.dart';

class DrawerTiles extends StatelessWidget {
  final String text;
  final String imageAssetSouce;
  final VoidCallback? ontap;
  const DrawerTiles({Key? key,required this.text, required this.imageAssetSouce, this.ontap})
      : super(key: key);

  @override
  Widget build(BuildContext context) {
    return InkWell(
      onTap: ontap,
      child: Padding(
        padding: const EdgeInsets.symmetric(horizontal: 30, vertical: 10),
        child: Row(
          children: [
            Padding(
              padding: const EdgeInsets.only(right: 10),
              child: Image.asset(
                    imageAssetSouce,
                    height: 30,
                    fit: BoxFit.fitHeight,
                  ),
            ),
            Text(text),
          ],
    
        ),
      ),
    );
  }
}
