import 'package:animated_card/animated_card.dart';
import 'package:flutter/material.dart';

import '../themes/app_images.dart';

class DrawerTiles extends StatelessWidget {
  final int? milliseconds;
  final String text;
  final String imageAssetSouce;
  final VoidCallback? ontap;
  final bool? isSelected;
  const DrawerTiles(
      {Key? key, required this.text, required this.imageAssetSouce, this.ontap, this.milliseconds, this.isSelected})
      : super(key: key);

  @override
  Widget build(BuildContext context) {
    return AnimatedCard(
      direction: AnimatedCardDirection.left,
      curve: Curves.easeInOutCubic, //Initial animation direction
      initDelay: Duration(milliseconds: 0), //Delay to initial animation
      duration: Duration(milliseconds: milliseconds ?? 100 ), //
      child: InkWell(
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
              Text(text, style: TextStyle(fontWeight: ((isSelected != null) || (isSelected == true)) ? FontWeight.bold : FontWeight.normal),),
            ],
          ),
        ),
      ),
    );
  }
}
