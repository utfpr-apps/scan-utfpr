import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:lottie/lottie.dart';
import 'package:scan/shared/themes/app_images.dart';

import '../../shared/themes/app_colors.dart';
import '../../shared/themes/app_text_styles.dart';
import '../../shared/widgets/button.dart';
import '../../shared/widgets/drawer_tiles.dart';

class SuccessPage extends StatefulWidget {
  const SuccessPage({Key? key}) : super(key: key);

  @override
  State<SuccessPage> createState() => _SuccessPageState();
}

class _SuccessPageState extends State<SuccessPage> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      drawer: SafeArea(
        child: Drawer(
          child: Column(
            children: [
              Padding(
                padding:
                    const EdgeInsets.symmetric(horizontal: 60, vertical: 25),
                child: Image.asset(
                  AppImages.logoUTFPR,
                  fit: BoxFit.fitHeight,
                ),
              ),
              Container(
                height: 1,
                color: Colors.grey.shade300,
              ),
              DrawerTiles(
                isSelected: true,
                imageAssetSouce: AppImages.qrCode,
                text: "Ler QR Code",
                ontap: () {Navigator.pushNamed(context, "scanner");},
              ),
              DrawerTiles(
                imageAssetSouce: AppImages.destaque,
                text: "Notificar COVID-19",
                ontap: () {
                  Navigator.pushNamed(context, "notification");
                  
                },
              ),
              DrawerTiles(
                imageAssetSouce: AppImages.download,
                text: "Sair do app",
                ontap: () {
                  SystemNavigator.pop();
                },
              ),
            ],
          ),
        ),
      ),
      appBar: AppBar(
        backgroundColor: AppColors.primary,
      ),
      body: Padding(
        padding: const EdgeInsets.symmetric(horizontal: 12, vertical: 50),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.center,
          children: [
            Center(
              child: RichText(
                textAlign: TextAlign.center,
                text: TextSpan(
                  style: AppTextStyles.normalRegular,
                  text: "",
                  children: [
                    TextSpan(text: "Tudo certo!", style: AppTextStyles.normalBold),
                    const TextSpan(
                      text: "\n\n\n",
                    ),
                  ],
                ),
              ),
            ),
            Padding(
              padding: const EdgeInsets.all(20),
              child: Lottie.asset("assets/anim/checked.json"),
            ),
            Button(
              title: "Concluir",
              onTap: () {
                Navigator.pushReplacementNamed(context, "home");
              },
            ),
          ],
        ),
      ),
    );
  }
}
