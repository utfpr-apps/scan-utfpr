import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:scan/shared/widgets/button.dart';
import '../../shared/themes/app_colors.dart';
import '../../shared/themes/app_text_styles.dart';
import '../../shared/widgets/drawer_tiles.dart';

class BlockPage extends StatefulWidget {
  const BlockPage({Key? key}) : super(key: key);

  @override
  State<BlockPage> createState() => _BlockPageState();
}

class _BlockPageState extends State<BlockPage> {
  List<int> horarios = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
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
                  "assets/images/logos/logo_utfpr.png",
                  fit: BoxFit.fitHeight,
                ),
              ),
              Container(
                height: 1,
                color: Colors.grey.shade300,
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
                  text:
                      "Nesta sala que você vai utilizar, cada bloco de tempo é de:",
                  children: [
                    TextSpan(
                        text: "\n50 min\n\n", style: AppTextStyles.bigBold),
                    const TextSpan(
                      text:
                          "Quantos blocos de horário você pretende utilizar nesta sala?",
                    ),
                  ],
                ),
              ),
            ),
            Padding(
              padding: const EdgeInsets.all(20),
              child: SizedBox(
                height: 200,
                child: CupertinoPicker(
                  onSelectedItemChanged: (index) {},
                  itemExtent: 70,
                  diameterRatio: 30,
                  looping: true,
                  children: horarios
                      .map(
                        (horario) => Center(
                          child: Text(horario.toString()),
                        ),
                      )
                      .toList(),
                ),
              ),
            ),
            Button(
              title: "Realizar check-in",
              onTap: () {
                Navigator.pushNamed(context, "block");
              },
            )
          ],
        ),
      ),
    );
  }
}
