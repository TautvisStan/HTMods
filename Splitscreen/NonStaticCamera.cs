//Game version 1.08
using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Splitscreen
{
    // Token: 0x02000004 RID: 4
    public static class CameraClassCopy
    {
        // Token: 0x06000009 RID: 9 RVA: 0x000020C0 File Offset: 0x000002C0
        public static void JLPLEOBKPCD()
        {
            if (CameraClassCopy.BPJFLJPKKJK != 5)
            {
                if (CameraClassCopy.CEKNDFGOILP > World.camNorth)
                {
                    CameraClassCopy.CEKNDFGOILP = World.camNorth;
                }
                if (CameraClassCopy.MOIMCJOBJME > World.camEast)
                {
                    CameraClassCopy.MOIMCJOBJME = World.camEast;
                }
                if (CameraClassCopy.CEKNDFGOILP < World.camSouth)
                {
                    CameraClassCopy.CEKNDFGOILP = World.camSouth;
                }
                if (CameraClassCopy.MOIMCJOBJME < World.camWest)
                {
                    CameraClassCopy.MOIMCJOBJME = World.camWest;
                }
            }
            float num = World.MBODMLMEHEP(CameraClassCopy.MOIMCJOBJME, CameraClassCopy.FNNBCDPJBIO, CameraClassCopy.CEKNDFGOILP);
            if (CameraClassCopy.HLMAFBJHCIK > num)
            {
                CameraClassCopy.HLMAFBJHCIK = num;
            }
            if (LIPNHOMGGHF.FAKHAFKOBPB > 0)
            {
                float num2 = World.KJOEBADBOME(CameraClassCopy.NJDGEELLAKG, CameraClassCopy.FNNBCDPJBIO, CameraClassCopy.BMFDFFLPBOJ);
                if (CameraClassCopy.HLMAFBJHCIK < num2 + 1f)
                {
                    CameraClassCopy.HLMAFBJHCIK = num2 + 1f;
                }
                if (GIMNNPMAKNJ.DGINJFACEDM == 1 && CameraClassCopy.HLMAFBJHCIK < num2 + 6f)
                {
                    CameraClassCopy.HLMAFBJHCIK = num2 + 6f;
                }
                if (CameraClassCopy.HLMAFBJHCIK < World.waterLevel + 1f)
                {
                    CameraClassCopy.HLMAFBJHCIK = World.waterLevel + 1f;
                }
            }
            if (LIPNHOMGGHF.FAKHAFKOBPB == 50 && World.ringShape > 0 && CameraClassCopy.HLMAFBJHCIK < World.ringGround + 1f)
            {
                CameraClassCopy.HLMAFBJHCIK = World.ringGround + 1f;
            }
            if (LIPNHOMGGHF.FAKHAFKOBPB == 50 && World.arenaShape > 0)
            {
                float num3 = 17f;
                if (NAEEIFNFBBO.GNCLMNEDIPL > 0 && World.crowdSize >= 0.25f)
                {
                    num3 = 14f;
                }
                if (CameraClassCopy.NJDGEELLAKG >= -num3 && CameraClassCopy.NJDGEELLAKG <= num3 && CameraClassCopy.BMFDFFLPBOJ > 67f)
                {
                    if (CameraClassCopy.MOIMCJOBJME < -num3)
                    {
                        CameraClassCopy.MOIMCJOBJME = -num3;
                    }
                    if (CameraClassCopy.MOIMCJOBJME > num3)
                    {
                        CameraClassCopy.MOIMCJOBJME = num3;
                    }
                }
                if (CameraClassCopy.BPJFLJPKKJK != 7 && (CameraClassCopy.MOIMCJOBJME < -num3 || CameraClassCopy.MOIMCJOBJME > num3 || CameraClassCopy.CEKNDFGOILP < 67f))
                {
                    float num4 = NAEEIFNFBBO.FHPCDHIGILG(CameraClassCopy.MOIMCJOBJME, CameraClassCopy.CEKNDFGOILP, 0f, 0f);
                    if (num4 > 51f && CameraClassCopy.HLMAFBJHCIK < num4 / 3f)
                    {
                        CameraClassCopy.HLMAFBJHCIK = num4 / 3f;
                    }
                }
            }
            if (World.location == 2)
            {
                if (CameraClassCopy.CMHIKHJGAGD < -63f)
                {
                    if (CameraClassCopy.MOIMCJOBJME < -14f)
                    {
                        CameraClassCopy.MOIMCJOBJME = -14f;
                    }
                    if (CameraClassCopy.MOIMCJOBJME > 14f)
                    {
                        CameraClassCopy.MOIMCJOBJME = 14f;
                    }
                    if (CameraClassCopy.HLMAFBJHCIK > 20f)
                    {
                        CameraClassCopy.HLMAFBJHCIK = 20f;
                    }
                }
                if (CameraClassCopy.MOIMCJOBJME > 53f && CameraClassCopy.CEKNDFGOILP < -52f)
                {
                    CameraClassCopy.CEKNDFGOILP = -52f;
                }
            }
            if (World.location == 8)
            {
                if (CameraClassCopy.BMFDFFLPBOJ > 30f && CameraClassCopy.HLMAFBJHCIK < 10f)
                {
                    CameraClassCopy.HLMAFBJHCIK = 10f;
                }
                if (CameraClassCopy.NJDGEELLAKG > -49f && CameraClassCopy.NJDGEELLAKG < 5f && CameraClassCopy.BMFDFFLPBOJ > 30f && CameraClassCopy.HLMAFBJHCIK > 24f)
                {
                    CameraClassCopy.HLMAFBJHCIK = 24f;
                }
            }
            if (World.location == 9)
            {
                if (CameraClassCopy.BMFDFFLPBOJ <= 49f)
                {
                    if (CameraClassCopy.CEKNDFGOILP > 35f)
                    {
                        CameraClassCopy.CEKNDFGOILP = 35f;
                    }
                }
                else
                {
                    if (CameraClassCopy.CEKNDFGOILP < 64f)
                    {
                        CameraClassCopy.CEKNDFGOILP = 64f;
                    }
                    if (CameraClassCopy.MOIMCJOBJME > 73f)
                    {
                        CameraClassCopy.MOIMCJOBJME = 73f;
                    }
                }
                if (CameraClassCopy.JBFIOOFDMND < -99f || CameraClassCopy.JBFIOOFDMND > 123f)
                {
                    if (CameraClassCopy.CMHIKHJGAGD > -12f && CameraClassCopy.CMHIKHJGAGD < 12f)
                    {
                        if (CameraClassCopy.CEKNDFGOILP > 7f)
                        {
                            CameraClassCopy.CEKNDFGOILP = 7f;
                        }
                        if (CameraClassCopy.CEKNDFGOILP < -7f)
                        {
                            CameraClassCopy.CEKNDFGOILP = -7f;
                        }
                    }
                    if (CameraClassCopy.CMHIKHJGAGD > 12f && CameraClassCopy.CEKNDFGOILP < 21f)
                    {
                        CameraClassCopy.CEKNDFGOILP = 21f;
                    }
                    if (CameraClassCopy.CMHIKHJGAGD < -12f && CameraClassCopy.CEKNDFGOILP > -21f)
                    {
                        CameraClassCopy.CEKNDFGOILP = -21f;
                    }
                }
            }
            if (World.location == 15)
            {
                if ((CameraClassCopy.NJDGEELLAKG < -15f || CameraClassCopy.NJDGEELLAKG > 15f || CameraClassCopy.MOIMCJOBJME < -15f || CameraClassCopy.MOIMCJOBJME > 15f) && CameraClassCopy.HLMAFBJHCIK > 15f)
                {
                    CameraClassCopy.HLMAFBJHCIK = 15f;
                }
                if (CameraClassCopy.CMHIKHJGAGD > 85f || CameraClassCopy.CMHIKHJGAGD < -83f)
                {
                    if (CameraClassCopy.JBFIOOFDMND < 0f)
                    {
                        CameraClassCopy.MOIMCJOBJME = -15f;
                    }
                    else
                    {
                        CameraClassCopy.MOIMCJOBJME = 15f;
                    }
                }
            }
            if (World.location == 16)
            {
                if ((CameraClassCopy.BMFDFFLPBOJ < -50f || CameraClassCopy.BMFDFFLPBOJ > 50f) && CameraClassCopy.HLMAFBJHCIK > 35f)
                {
                    CameraClassCopy.HLMAFBJHCIK = 35f;
                }
                if (CameraClassCopy.CMHIKHJGAGD > 50f || CameraClassCopy.CMHIKHJGAGD < -50f)
                {
                    if (CameraClassCopy.MOIMCJOBJME < -62f)
                    {
                        CameraClassCopy.MOIMCJOBJME = -62f;
                    }
                    if (CameraClassCopy.MOIMCJOBJME > 62f)
                    {
                        CameraClassCopy.MOIMCJOBJME = 62f;
                    }
                }
            }
            if ((World.location == 17 || World.location == 27) && CameraClassCopy.CEKNDFGOILP < 28f)
            {
                float num5 = 2f;
                num5 += 0.1f * Mathf.Abs(28f - CameraClassCopy.CEKNDFGOILP);
                if (CameraClassCopy.HLMAFBJHCIK < num5)
                {
                    CameraClassCopy.HLMAFBJHCIK = num5;
                }
            }
            if (World.location == 18 && CameraClassCopy.CEKNDFGOILP < -70f && CameraClassCopy.HLMAFBJHCIK < World.ground)
            {
                CameraClassCopy.HLMAFBJHCIK = World.ground;
            }
            if (World.location == 22 && CameraClassCopy.GIBHLNFEPKE == 0f && CameraClassCopy.BPJFLJPKKJK != 0)
            {
                if (CameraClassCopy.JBFIOOFDMND < -52f && CameraClassCopy.CMHIKHJGAGD > -48f && CameraClassCopy.CEKNDFGOILP < -48f)
                {
                    CameraClassCopy.CEKNDFGOILP = -48f;
                }
                if (CameraClassCopy.JBFIOOFDMND > -52f && CameraClassCopy.CMHIKHJGAGD < -48f && CameraClassCopy.MOIMCJOBJME < -52f)
                {
                    CameraClassCopy.MOIMCJOBJME = -52f;
                }
                if (CameraClassCopy.JBFIOOFDMND < -52f && CameraClassCopy.CMHIKHJGAGD < 50f && CameraClassCopy.CEKNDFGOILP > 50f)
                {
                    CameraClassCopy.CEKNDFGOILP = 50f;
                }
                if (CameraClassCopy.JBFIOOFDMND > -52f && CameraClassCopy.CMHIKHJGAGD > 50f && CameraClassCopy.MOIMCJOBJME < -52f)
                {
                    CameraClassCopy.MOIMCJOBJME = -52f;
                }
                if (CameraClassCopy.JBFIOOFDMND > 51.5f && CameraClassCopy.CMHIKHJGAGD < 51f && CameraClassCopy.CEKNDFGOILP > 51f)
                {
                    CameraClassCopy.CEKNDFGOILP = 51f;
                }
                if (CameraClassCopy.JBFIOOFDMND < 51.5f && CameraClassCopy.CMHIKHJGAGD > 51f && CameraClassCopy.MOIMCJOBJME > 51.5f)
                {
                    CameraClassCopy.MOIMCJOBJME = 51.5f;
                }
            }
            if (World.location == 25)
            {
                if (CameraClassCopy.JBFIOOFDMND < 0f && CameraClassCopy.CMHIKHJGAGD >= 14.5f)
                {
                    if (CameraClassCopy.MOIMCJOBJME < -14.5f)
                    {
                        CameraClassCopy.MOIMCJOBJME = -14.5f;
                    }
                    if (CameraClassCopy.MOIMCJOBJME > -9f)
                    {
                        CameraClassCopy.MOIMCJOBJME = -9f;
                    }
                    if (CameraClassCopy.HLMAFBJHCIK > 15f)
                    {
                        CameraClassCopy.HLMAFBJHCIK = 15f;
                    }
                }
                if (CameraClassCopy.JBFIOOFDMND > 0f && CameraClassCopy.CMHIKHJGAGD > 9f)
                {
                    if (CameraClassCopy.MOIMCJOBJME < 8f)
                    {
                        CameraClassCopy.MOIMCJOBJME = 8f;
                    }
                    if (CameraClassCopy.MOIMCJOBJME > 11f)
                    {
                        CameraClassCopy.MOIMCJOBJME = 11f;
                    }
                    if (CameraClassCopy.HLMAFBJHCIK > 15f)
                    {
                        CameraClassCopy.HLMAFBJHCIK = 15f;
                    }
                }
            }
            if (World.location == 27 && CameraClassCopy.CMHIKHJGAGD > 73f)
            {
                if (CameraClassCopy.MOIMCJOBJME < -57f)
                {
                    CameraClassCopy.MOIMCJOBJME = -57f;
                }
                if (CameraClassCopy.MOIMCJOBJME > 57f)
                {
                    CameraClassCopy.MOIMCJOBJME = 57f;
                }
            }
            if (World.location == 28)
            {
                if (CameraClassCopy.CMHIKHJGAGD < -92f)
                {
                    if (CameraClassCopy.JBFIOOFDMND >= -11f && CameraClassCopy.JBFIOOFDMND <= 11f && CameraClassCopy.MOIMCJOBJME < 11f)
                    {
                        CameraClassCopy.MOIMCJOBJME = 11f;
                    }
                    if (CameraClassCopy.JBFIOOFDMND >= -11f && CameraClassCopy.JBFIOOFDMND <= 11f && CameraClassCopy.MOIMCJOBJME > -11f)
                    {
                        CameraClassCopy.MOIMCJOBJME = -11f;
                    }
                    if (CameraClassCopy.JBFIOOFDMND >= 76f && CameraClassCopy.MOIMCJOBJME < 76f)
                    {
                        CameraClassCopy.MOIMCJOBJME = 76f;
                    }
                    if (CameraClassCopy.JBFIOOFDMND <= -76f && CameraClassCopy.MOIMCJOBJME > -76f)
                    {
                        CameraClassCopy.MOIMCJOBJME = -76f;
                    }
                }
                if (CameraClassCopy.JBFIOOFDMND > -76f && CameraClassCopy.JBFIOOFDMND < 76f && CameraClassCopy.CEKNDFGOILP < -92f)
                {
                    CameraClassCopy.CEKNDFGOILP = -92f;
                }
                if (((CameraClassCopy.CMHIKHJGAGD > 71f && CameraClassCopy.BMFDFFLPBOJ < 71f) || (CameraClassCopy.CMHIKHJGAGD < 71f && CameraClassCopy.BMFDFFLPBOJ > 71f)) && CameraClassCopy.HLMAFBJHCIK < World.ground + 20f)
                {
                    CameraClassCopy.HLMAFBJHCIK = World.ground + 20f;
                }
                if (CameraClassCopy.JBFIOOFDMND > 52f && CameraClassCopy.CMHIKHJGAGD <= 173f && CameraClassCopy.CEKNDFGOILP > 173f)
                {
                    CameraClassCopy.CEKNDFGOILP = 173f;
                }
                if (CameraClassCopy.JBFIOOFDMND <= 52f && CameraClassCopy.CMHIKHJGAGD > 173f && CameraClassCopy.MOIMCJOBJME > 52f)
                {
                    CameraClassCopy.MOIMCJOBJME = 52f;
                }
            }
            if (World.location == 29)
            {
                if (CameraClassCopy.CMHIKHJGAGD >= 0f && CameraClassCopy.JBFIOOFDMND > 0f)
                {
                    if (CameraClassCopy.BMFDFFLPBOJ < 0f && CameraClassCopy.MOIMCJOBJME > 0f)
                    {
                        CameraClassCopy.MOIMCJOBJME = 0f;
                    }
                    if (CameraClassCopy.CEKNDFGOILP < 0f)
                    {
                        CameraClassCopy.CEKNDFGOILP = 0f;
                    }
                }
                if (CameraClassCopy.CMHIKHJGAGD < 0f && CameraClassCopy.JBFIOOFDMND <= 0f && CameraClassCopy.MOIMCJOBJME > 0f)
                {
                    CameraClassCopy.MOIMCJOBJME = 0f;
                }
            }
            if (World.location == 30)
            {
                if (CameraClassCopy.CMHIKHJGAGD >= 45f && CameraClassCopy.JBFIOOFDMND > -46f && CameraClassCopy.JBFIOOFDMND < 46f)
                {
                    if (CameraClassCopy.CEKNDFGOILP < 46f)
                    {
                        CameraClassCopy.CEKNDFGOILP = 46f;
                    }
                    if (CameraClassCopy.BMFDFFLPBOJ <= -45f && CameraClassCopy.MOIMCJOBJME > -46f && CameraClassCopy.MOIMCJOBJME < 46f)
                    {
                        if (CameraClassCopy.NJDGEELLAKG < 0f)
                        {
                            CameraClassCopy.MOIMCJOBJME = -46f;
                        }
                        else
                        {
                            CameraClassCopy.MOIMCJOBJME = 46f;
                        }
                    }
                }
                if (CameraClassCopy.CMHIKHJGAGD <= -45f && CameraClassCopy.JBFIOOFDMND > -46f && CameraClassCopy.JBFIOOFDMND < 46f)
                {
                    if (CameraClassCopy.CEKNDFGOILP > -46f)
                    {
                        CameraClassCopy.CEKNDFGOILP = -46f;
                    }
                    if (CameraClassCopy.BMFDFFLPBOJ >= 45f && CameraClassCopy.MOIMCJOBJME > -46f && CameraClassCopy.MOIMCJOBJME < 46f)
                    {
                        if (CameraClassCopy.NJDGEELLAKG < 0f)
                        {
                            CameraClassCopy.MOIMCJOBJME = -46f;
                        }
                        else
                        {
                            CameraClassCopy.MOIMCJOBJME = 46f;
                        }
                    }
                }
                if (CameraClassCopy.JBFIOOFDMND >= 45f && CameraClassCopy.CEKNDFGOILP > -46f && CameraClassCopy.CEKNDFGOILP < 46f)
                {
                    if (CameraClassCopy.MOIMCJOBJME < 46f)
                    {
                        CameraClassCopy.MOIMCJOBJME = 46f;
                    }
                    if (CameraClassCopy.NJDGEELLAKG <= -45f && CameraClassCopy.CEKNDFGOILP > -46f && CameraClassCopy.CEKNDFGOILP < 46f)
                    {
                        if (CameraClassCopy.BMFDFFLPBOJ < 0f)
                        {
                            CameraClassCopy.CEKNDFGOILP = -46f;
                        }
                        else
                        {
                            CameraClassCopy.CEKNDFGOILP = 46f;
                        }
                    }
                }
                if (CameraClassCopy.JBFIOOFDMND <= -45f && CameraClassCopy.CEKNDFGOILP > -46f && CameraClassCopy.CEKNDFGOILP < 46f)
                {
                    if (CameraClassCopy.MOIMCJOBJME > -46f)
                    {
                        CameraClassCopy.MOIMCJOBJME = -46f;
                    }
                    if (CameraClassCopy.NJDGEELLAKG >= 45f && CameraClassCopy.CEKNDFGOILP > -46f && CameraClassCopy.CEKNDFGOILP < 46f)
                    {
                        if (CameraClassCopy.BMFDFFLPBOJ < 0f)
                        {
                            CameraClassCopy.CEKNDFGOILP = -46f;
                        }
                        else
                        {
                            CameraClassCopy.CEKNDFGOILP = 46f;
                        }
                    }
                }
                if (CameraClassCopy.CMHIKHJGAGD > 81f)
                {
                    if (CameraClassCopy.MOIMCJOBJME < -14f)
                    {
                        CameraClassCopy.MOIMCJOBJME = -14f;
                    }
                    if (CameraClassCopy.MOIMCJOBJME > 14f)
                    {
                        CameraClassCopy.MOIMCJOBJME = 14f;
                    }
                }
            }
            if (World.location == 40)
            {
                if (CameraClassCopy.CMHIKHJGAGD > -3.5f)
                {
                    if (CameraClassCopy.MOIMCJOBJME < -22f)
                    {
                        CameraClassCopy.MOIMCJOBJME = -22f;
                    }
                    if (CameraClassCopy.MOIMCJOBJME > 22f)
                    {
                        CameraClassCopy.MOIMCJOBJME = 22f;
                    }
                }
                if (CameraClassCopy.CMHIKHJGAGD <= -3.5f && (CameraClassCopy.JBFIOOFDMND < -22f || CameraClassCopy.JBFIOOFDMND > 22f) && CameraClassCopy.CEKNDFGOILP > -3.5f)
                {
                    CameraClassCopy.CEKNDFGOILP = -3.5f;
                }
            }
            if (GIMNNPMAKNJ.DGINJFACEDM == 1 && CameraClassCopy.GIBHLNFEPKE == 0f && CameraClassCopy.BPJFLJPKKJK != 0)
            {
                int num6 = GIMNNPMAKNJ.HOJMKAGHOJG(CameraClassCopy.JBFIOOFDMND, CameraClassCopy.IKLMALGHGFI, CameraClassCopy.CMHIKHJGAGD, 6f);
                if (num6 > 0)
                {
                    Debug.Log(string.Concat(new string[]
                    {
                    "focCell=",
                    num6.ToString(),
                    " tX/Z=",
                    CameraClassCopy.MOIMCJOBJME.ToString(),
                    " x ",
                    CameraClassCopy.CEKNDFGOILP.ToString(),
                    " vs cellX=",
                    GIMNNPMAKNJ.ENAONNGGEPN[num6].ToString()
                    }));
                    if (num6 == 4 || num6 == 5 || num6 == 12 || num6 == 13)
                    {
                        if (CameraClassCopy.MOIMCJOBJME < GIMNNPMAKNJ.ENAONNGGEPN[num6] - GIMNNPMAKNJ.MPGEKNKCOCA[num6])
                        {
                            CameraClassCopy.MOIMCJOBJME = GIMNNPMAKNJ.ENAONNGGEPN[num6] - GIMNNPMAKNJ.MPGEKNKCOCA[num6];
                        }
                        if (CameraClassCopy.MOIMCJOBJME > GIMNNPMAKNJ.ENAONNGGEPN[num6] + GIMNNPMAKNJ.MPGEKNKCOCA[num6])
                        {
                            CameraClassCopy.MOIMCJOBJME = GIMNNPMAKNJ.ENAONNGGEPN[num6] + GIMNNPMAKNJ.MPGEKNKCOCA[num6];
                        }
                        if ((CameraClassCopy.NJDGEELLAKG < GIMNNPMAKNJ.ENAONNGGEPN[num6] - GIMNNPMAKNJ.MPGEKNKCOCA[num6] || CameraClassCopy.NJDGEELLAKG > GIMNNPMAKNJ.ENAONNGGEPN[num6] + GIMNNPMAKNJ.MPGEKNKCOCA[num6]) && CameraClassCopy.CEKNDFGOILP > 75f)
                        {
                            CameraClassCopy.CEKNDFGOILP = 75f;
                        }
                    }
                    else
                    {
                        if (CameraClassCopy.CEKNDFGOILP < GIMNNPMAKNJ.OJOPMEJFHHH[num6] - GIMNNPMAKNJ.LPMMBNFOKHM[num6])
                        {
                            CameraClassCopy.CEKNDFGOILP = GIMNNPMAKNJ.OJOPMEJFHHH[num6] - GIMNNPMAKNJ.LPMMBNFOKHM[num6];
                        }
                        if (CameraClassCopy.CEKNDFGOILP > GIMNNPMAKNJ.OJOPMEJFHHH[num6] + GIMNNPMAKNJ.LPMMBNFOKHM[num6])
                        {
                            CameraClassCopy.CEKNDFGOILP = GIMNNPMAKNJ.OJOPMEJFHHH[num6] + GIMNNPMAKNJ.LPMMBNFOKHM[num6];
                        }
                        if (CameraClassCopy.BMFDFFLPBOJ < GIMNNPMAKNJ.OJOPMEJFHHH[num6] - GIMNNPMAKNJ.LPMMBNFOKHM[num6] || CameraClassCopy.BMFDFFLPBOJ > GIMNNPMAKNJ.OJOPMEJFHHH[num6] + GIMNNPMAKNJ.LPMMBNFOKHM[num6])
                        {
                            if (CameraClassCopy.MOIMCJOBJME < -77f)
                            {
                                CameraClassCopy.MOIMCJOBJME = -77f;
                            }
                            if (CameraClassCopy.MOIMCJOBJME > 76f)
                            {
                                CameraClassCopy.MOIMCJOBJME = 76f;
                            }
                        }
                    }
                }
                int num7 = GIMNNPMAKNJ.HOJMKAGHOJG(CameraClassCopy.NJDGEELLAKG, CameraClassCopy.FNNBCDPJBIO, CameraClassCopy.BMFDFFLPBOJ, 6f);
                if (num7 == 0)
                {
                    num7 = GIMNNPMAKNJ.HOJMKAGHOJG(CameraClassCopy.MOIMCJOBJME, CameraClassCopy.HLMAFBJHCIK, CameraClassCopy.CEKNDFGOILP, 6f);
                }
                if (num7 > 0 && num6 != num7)
                {
                    Debug.Log(string.Concat(new string[]
                    {
                    "camCell=",
                    num7.ToString(),
                    " tX/Z=",
                    CameraClassCopy.MOIMCJOBJME.ToString(),
                    " x ",
                    CameraClassCopy.CEKNDFGOILP.ToString(),
                    " vs cellX=",
                    GIMNNPMAKNJ.ENAONNGGEPN[num7].ToString()
                    }));
                    if (num7 == 4 || num7 == 5 || num7 == 12 || num7 == 13)
                    {
                        if ((CameraClassCopy.MOIMCJOBJME < GIMNNPMAKNJ.ENAONNGGEPN[num7] - GIMNNPMAKNJ.MPGEKNKCOCA[num7] || CameraClassCopy.MOIMCJOBJME > GIMNNPMAKNJ.ENAONNGGEPN[num7] + GIMNNPMAKNJ.MPGEKNKCOCA[num7]) && CameraClassCopy.CEKNDFGOILP > 75f)
                        {
                            CameraClassCopy.CEKNDFGOILP = 75f;
                        }
                    }
                    else if (CameraClassCopy.CEKNDFGOILP < GIMNNPMAKNJ.OJOPMEJFHHH[num7] - GIMNNPMAKNJ.LPMMBNFOKHM[num7] || CameraClassCopy.CEKNDFGOILP > GIMNNPMAKNJ.OJOPMEJFHHH[num7] + GIMNNPMAKNJ.LPMMBNFOKHM[num7])
                    {
                        if (CameraClassCopy.MOIMCJOBJME < -77f)
                        {
                            CameraClassCopy.MOIMCJOBJME = -77f;
                        }
                        if (CameraClassCopy.MOIMCJOBJME > 76f)
                        {
                            CameraClassCopy.MOIMCJOBJME = 76f;
                        }
                    }
                }
                if (CameraClassCopy.CMHIKHJGAGD < -34.5f && CameraClassCopy.BMFDFFLPBOJ >= -34.5f)
                {
                    if (CameraClassCopy.MOIMCJOBJME < -55f)
                    {
                        CameraClassCopy.MOIMCJOBJME = -55f;
                    }
                    if (CameraClassCopy.MOIMCJOBJME > 53f)
                    {
                        CameraClassCopy.MOIMCJOBJME = 53f;
                    }
                }
                if (CameraClassCopy.CMHIKHJGAGD >= -34.5f && (CameraClassCopy.MOIMCJOBJME < -55f || CameraClassCopy.MOIMCJOBJME > 53f) && CameraClassCopy.CEKNDFGOILP < -34.5f)
                {
                    CameraClassCopy.CEKNDFGOILP = -34.5f;
                }
                if (((CameraClassCopy.JBFIOOFDMND < -34f && CameraClassCopy.NJDGEELLAKG >= -34f) || (CameraClassCopy.JBFIOOFDMND > 33f && CameraClassCopy.NJDGEELLAKG <= 33f)) && CameraClassCopy.CEKNDFGOILP > 75f)
                {
                    CameraClassCopy.CEKNDFGOILP = 75f;
                }
                if (CameraClassCopy.IKLMALGHGFI > 25f && CameraClassCopy.FNNBCDPJBIO < 25f)
                {
                    if (CameraClassCopy.CEKNDFGOILP > 55f)
                    {
                        CameraClassCopy.CEKNDFGOILP = 55f;
                    }
                    if (CameraClassCopy.MOIMCJOBJME > 55f)
                    {
                        CameraClassCopy.MOIMCJOBJME = 55f;
                    }
                    if (CameraClassCopy.MOIMCJOBJME < -55f)
                    {
                        CameraClassCopy.MOIMCJOBJME = -55f;
                    }
                }
                if (CameraClassCopy.IKLMALGHGFI < 30f && CameraClassCopy.FNNBCDPJBIO >= 30f)
                {
                    if (CameraClassCopy.MOIMCJOBJME < -55f)
                    {
                        CameraClassCopy.MOIMCJOBJME = -55f;
                    }
                    if (CameraClassCopy.MOIMCJOBJME > 53f)
                    {
                        CameraClassCopy.MOIMCJOBJME = 53f;
                    }
                    if (CameraClassCopy.CEKNDFGOILP > 55f)
                    {
                        CameraClassCopy.CEKNDFGOILP = 55f;
                    }
                }
                if (CameraClassCopy.IKLMALGHGFI < 30f && CameraClassCopy.CMHIKHJGAGD > 0f)
                {
                    if (CameraClassCopy.JBFIOOFDMND < -20f && CameraClassCopy.MOIMCJOBJME > -23.5f)
                    {
                        CameraClassCopy.MOIMCJOBJME = -23.5f;
                    }
                    if (CameraClassCopy.JBFIOOFDMND > 20f && CameraClassCopy.MOIMCJOBJME < 22f)
                    {
                        CameraClassCopy.MOIMCJOBJME = 22f;
                    }
                }
                if ((CameraClassCopy.NJDGEELLAKG < -55f || CameraClassCopy.NJDGEELLAKG > 53f || CameraClassCopy.BMFDFFLPBOJ > 55f) && CameraClassCopy.IKLMALGHGFI < 24f && CameraClassCopy.HLMAFBJHCIK > 20f && CameraClassCopy.FNNBCDPJBIO < 30f)
                {
                    CameraClassCopy.HLMAFBJHCIK = 20f;
                }
                float num8 = World.KJOEBADBOME(CameraClassCopy.JBFIOOFDMND, 0f, CameraClassCopy.BMFDFFLPBOJ);
                if (CameraClassCopy.HLMAFBJHCIK < num8 + 6f)
                {
                    CameraClassCopy.HLMAFBJHCIK = num8 + 6f;
                }
                if (((CameraClassCopy.JBFIOOFDMND < -20f && CameraClassCopy.NJDGEELLAKG > -20f) || (CameraClassCopy.JBFIOOFDMND > 20f && CameraClassCopy.NJDGEELLAKG < 20f)) && CameraClassCopy.CMHIKHJGAGD > -16f)
                {
                    num8 = World.KJOEBADBOME(0f, 0f, CameraClassCopy.BMFDFFLPBOJ);
                    if (CameraClassCopy.HLMAFBJHCIK < num8 + 6f)
                    {
                        CameraClassCopy.HLMAFBJHCIK = num8 + 6f;
                    }
                }
            }
            if (GIMNNPMAKNJ.DGINJFACEDM == 2 && CameraClassCopy.GIBHLNFEPKE == 0f && CameraClassCopy.BPJFLJPKKJK != 0)
            {
                int num9 = GIMNNPMAKNJ.HOJMKAGHOJG(CameraClassCopy.JBFIOOFDMND, CameraClassCopy.IKLMALGHGFI, CameraClassCopy.CMHIKHJGAGD, 6f);
                if (num9 > 0)
                {
                    if (CameraClassCopy.MOIMCJOBJME < GIMNNPMAKNJ.ENAONNGGEPN[num9] - GIMNNPMAKNJ.MPGEKNKCOCA[num9])
                    {
                        CameraClassCopy.MOIMCJOBJME = GIMNNPMAKNJ.ENAONNGGEPN[num9] - GIMNNPMAKNJ.MPGEKNKCOCA[num9];
                    }
                    if (CameraClassCopy.MOIMCJOBJME > GIMNNPMAKNJ.ENAONNGGEPN[num9] + GIMNNPMAKNJ.MPGEKNKCOCA[num9])
                    {
                        CameraClassCopy.MOIMCJOBJME = GIMNNPMAKNJ.ENAONNGGEPN[num9] + GIMNNPMAKNJ.MPGEKNKCOCA[num9];
                    }
                    if (CameraClassCopy.NJDGEELLAKG < GIMNNPMAKNJ.ENAONNGGEPN[num9] - GIMNNPMAKNJ.MPGEKNKCOCA[num9] || CameraClassCopy.NJDGEELLAKG > GIMNNPMAKNJ.ENAONNGGEPN[num9] + GIMNNPMAKNJ.MPGEKNKCOCA[num9])
                    {
                        if (CameraClassCopy.CEKNDFGOILP < -19f)
                        {
                            CameraClassCopy.CEKNDFGOILP = -19f;
                        }
                        if (CameraClassCopy.CEKNDFGOILP > 19f)
                        {
                            CameraClassCopy.CEKNDFGOILP = 19f;
                        }
                    }
                }
                int num10 = GIMNNPMAKNJ.HOJMKAGHOJG(CameraClassCopy.NJDGEELLAKG, CameraClassCopy.FNNBCDPJBIO, CameraClassCopy.BMFDFFLPBOJ, 6f);
                if (num10 == 0)
                {
                    num10 = GIMNNPMAKNJ.HOJMKAGHOJG(CameraClassCopy.MOIMCJOBJME, CameraClassCopy.HLMAFBJHCIK, CameraClassCopy.CEKNDFGOILP, 6f);
                }
                if (num10 > 0 && num9 != num10 && (CameraClassCopy.MOIMCJOBJME < GIMNNPMAKNJ.ENAONNGGEPN[num10] - GIMNNPMAKNJ.MPGEKNKCOCA[num10] || CameraClassCopy.MOIMCJOBJME > GIMNNPMAKNJ.ENAONNGGEPN[num10] + GIMNNPMAKNJ.MPGEKNKCOCA[num10]))
                {
                    Debug.Log(string.Concat(new string[]
                    {
                    "Helping ",
                    CameraClassCopy.MOIMCJOBJME.ToString(),
                    " x ",
                    CameraClassCopy.CEKNDFGOILP.ToString(),
                    " out of camCell=",
                    num10.ToString()
                    }));
                    if (CameraClassCopy.CEKNDFGOILP < -19f)
                    {
                        CameraClassCopy.CEKNDFGOILP = -19f;
                    }
                    if (CameraClassCopy.CEKNDFGOILP > 19f)
                    {
                        CameraClassCopy.CEKNDFGOILP = 19f;
                    }
                }
                if ((CameraClassCopy.JBFIOOFDMND < -22f && CameraClassCopy.NJDGEELLAKG >= -22f) || (CameraClassCopy.JBFIOOFDMND > 22f && CameraClassCopy.NJDGEELLAKG <= 22f))
                {
                    if (CameraClassCopy.CEKNDFGOILP < -19f)
                    {
                        CameraClassCopy.CEKNDFGOILP = -19f;
                    }
                    if (CameraClassCopy.CEKNDFGOILP > 19f)
                    {
                        CameraClassCopy.CEKNDFGOILP = 19f;
                    }
                }
                if (CameraClassCopy.JBFIOOFDMND >= -22f && CameraClassCopy.JBFIOOFDMND <= 22f && (CameraClassCopy.MOIMCJOBJME < -22f || CameraClassCopy.MOIMCJOBJME > 22f))
                {
                    if (CameraClassCopy.CMHIKHJGAGD < -19f || CameraClassCopy.CMHIKHJGAGD >= 19f)
                    {
                        if (CameraClassCopy.MOIMCJOBJME < -22f)
                        {
                            CameraClassCopy.MOIMCJOBJME = -22f;
                        }
                        if (CameraClassCopy.MOIMCJOBJME > 22f)
                        {
                            CameraClassCopy.MOIMCJOBJME = 22f;
                        }
                        if (CameraClassCopy.CMHIKHJGAGD <= -19f && CameraClassCopy.CEKNDFGOILP < -19f)
                        {
                            CameraClassCopy.CEKNDFGOILP = -19f;
                        }
                        if (CameraClassCopy.CMHIKHJGAGD >= 19f && CameraClassCopy.CEKNDFGOILP > 19f)
                        {
                            CameraClassCopy.CEKNDFGOILP = 19f;
                        }
                    }
                    if (CameraClassCopy.CEKNDFGOILP < -19f)
                    {
                        CameraClassCopy.CEKNDFGOILP = -19f;
                    }
                    if (CameraClassCopy.CEKNDFGOILP > 19f)
                    {
                        CameraClassCopy.CEKNDFGOILP = 19f;
                    }
                }
            }
            if (GIMNNPMAKNJ.DGINJFACEDM == 4 && CameraClassCopy.GIBHLNFEPKE == 0f && CameraClassCopy.BPJFLJPKKJK != 0)
            {
                int num11 = GIMNNPMAKNJ.HOJMKAGHOJG(CameraClassCopy.JBFIOOFDMND, CameraClassCopy.IKLMALGHGFI, CameraClassCopy.CMHIKHJGAGD, 6f);
                if (num11 > 0)
                {
                    if (num11 == 3 || num11 == 4 || num11 == 9 || num11 == 10)
                    {
                        if (CameraClassCopy.CEKNDFGOILP < GIMNNPMAKNJ.OJOPMEJFHHH[num11] - GIMNNPMAKNJ.LPMMBNFOKHM[num11])
                        {
                            CameraClassCopy.CEKNDFGOILP = GIMNNPMAKNJ.OJOPMEJFHHH[num11] - GIMNNPMAKNJ.LPMMBNFOKHM[num11];
                        }
                        if (CameraClassCopy.CEKNDFGOILP > GIMNNPMAKNJ.OJOPMEJFHHH[num11] + GIMNNPMAKNJ.LPMMBNFOKHM[num11])
                        {
                            CameraClassCopy.CEKNDFGOILP = GIMNNPMAKNJ.OJOPMEJFHHH[num11] + GIMNNPMAKNJ.LPMMBNFOKHM[num11];
                        }
                        if (CameraClassCopy.BMFDFFLPBOJ < GIMNNPMAKNJ.OJOPMEJFHHH[num11] - GIMNNPMAKNJ.LPMMBNFOKHM[num11] || CameraClassCopy.BMFDFFLPBOJ > GIMNNPMAKNJ.OJOPMEJFHHH[num11] + GIMNNPMAKNJ.LPMMBNFOKHM[num11])
                        {
                            if (CameraClassCopy.MOIMCJOBJME < -102f)
                            {
                                CameraClassCopy.MOIMCJOBJME = -102f;
                            }
                            if (CameraClassCopy.MOIMCJOBJME > 102f)
                            {
                                CameraClassCopy.MOIMCJOBJME = 102f;
                            }
                        }
                    }
                    else
                    {
                        if (CameraClassCopy.MOIMCJOBJME < GIMNNPMAKNJ.ENAONNGGEPN[num11] - GIMNNPMAKNJ.MPGEKNKCOCA[num11])
                        {
                            CameraClassCopy.MOIMCJOBJME = GIMNNPMAKNJ.ENAONNGGEPN[num11] - GIMNNPMAKNJ.MPGEKNKCOCA[num11];
                        }
                        if (CameraClassCopy.MOIMCJOBJME > GIMNNPMAKNJ.ENAONNGGEPN[num11] + GIMNNPMAKNJ.MPGEKNKCOCA[num11])
                        {
                            CameraClassCopy.MOIMCJOBJME = GIMNNPMAKNJ.ENAONNGGEPN[num11] + GIMNNPMAKNJ.MPGEKNKCOCA[num11];
                        }
                        if (CameraClassCopy.NJDGEELLAKG < GIMNNPMAKNJ.ENAONNGGEPN[num11] - GIMNNPMAKNJ.MPGEKNKCOCA[num11] || CameraClassCopy.NJDGEELLAKG > GIMNNPMAKNJ.ENAONNGGEPN[num11] + GIMNNPMAKNJ.MPGEKNKCOCA[num11])
                        {
                            if (CameraClassCopy.CEKNDFGOILP < -62f)
                            {
                                CameraClassCopy.CEKNDFGOILP = -62f;
                            }
                            if (CameraClassCopy.CEKNDFGOILP > 62f)
                            {
                                CameraClassCopy.CEKNDFGOILP = 62f;
                            }
                        }
                    }
                }
                int num12 = GIMNNPMAKNJ.HOJMKAGHOJG(CameraClassCopy.NJDGEELLAKG, CameraClassCopy.FNNBCDPJBIO, CameraClassCopy.BMFDFFLPBOJ, 6f);
                if (num12 == 0)
                {
                    num12 = GIMNNPMAKNJ.HOJMKAGHOJG(CameraClassCopy.MOIMCJOBJME, CameraClassCopy.HLMAFBJHCIK, CameraClassCopy.CEKNDFGOILP, 6f);
                }
                if (num12 > 0 && num11 != num12)
                {
                    if (num12 == 3 || num12 == 4 || num12 == 9 || num12 == 10)
                    {
                        if (CameraClassCopy.CEKNDFGOILP < GIMNNPMAKNJ.OJOPMEJFHHH[num12] - GIMNNPMAKNJ.LPMMBNFOKHM[num12] || CameraClassCopy.CEKNDFGOILP > GIMNNPMAKNJ.OJOPMEJFHHH[num12] + GIMNNPMAKNJ.LPMMBNFOKHM[num12])
                        {
                            Debug.Log(string.Concat(new string[]
                            {
                            "Helping ",
                            CameraClassCopy.MOIMCJOBJME.ToString(),
                            " x ",
                            CameraClassCopy.CEKNDFGOILP.ToString(),
                            " out of camCell=",
                            num12.ToString()
                            }));
                            if (CameraClassCopy.MOIMCJOBJME < -102f)
                            {
                                CameraClassCopy.MOIMCJOBJME = -102f;
                            }
                            if (CameraClassCopy.MOIMCJOBJME > 102f)
                            {
                                CameraClassCopy.MOIMCJOBJME = 102f;
                            }
                        }
                    }
                    else if (CameraClassCopy.MOIMCJOBJME < GIMNNPMAKNJ.ENAONNGGEPN[num12] - GIMNNPMAKNJ.MPGEKNKCOCA[num12] || CameraClassCopy.MOIMCJOBJME > GIMNNPMAKNJ.ENAONNGGEPN[num12] + GIMNNPMAKNJ.MPGEKNKCOCA[num12])
                    {
                        Debug.Log(string.Concat(new string[]
                        {
                        "Helping ",
                        CameraClassCopy.MOIMCJOBJME.ToString(),
                        " x ",
                        CameraClassCopy.CEKNDFGOILP.ToString(),
                        " out of camCell=",
                        num12.ToString()
                        }));
                        if (CameraClassCopy.CEKNDFGOILP < -62f)
                        {
                            CameraClassCopy.CEKNDFGOILP = -62f;
                        }
                        if (CameraClassCopy.CEKNDFGOILP > 62f)
                        {
                            CameraClassCopy.CEKNDFGOILP = 62f;
                        }
                    }
                }
                if ((CameraClassCopy.JBFIOOFDMND < -22f && CameraClassCopy.NJDGEELLAKG >= -22f) || (CameraClassCopy.JBFIOOFDMND > 22f && CameraClassCopy.NJDGEELLAKG <= 22f))
                {
                    if (CameraClassCopy.CEKNDFGOILP < -62f)
                    {
                        CameraClassCopy.CEKNDFGOILP = -62f;
                    }
                    if (CameraClassCopy.CEKNDFGOILP > 62f)
                    {
                        CameraClassCopy.CEKNDFGOILP = 62f;
                    }
                }
                if (CameraClassCopy.JBFIOOFDMND >= -22f && CameraClassCopy.JBFIOOFDMND <= 22f && (CameraClassCopy.MOIMCJOBJME < -22f || CameraClassCopy.MOIMCJOBJME > 22f))
                {
                    if (CameraClassCopy.CMHIKHJGAGD < -62f || CameraClassCopy.CMHIKHJGAGD >= 62f)
                    {
                        if (CameraClassCopy.MOIMCJOBJME < -22f)
                        {
                            CameraClassCopy.MOIMCJOBJME = -22f;
                        }
                        if (CameraClassCopy.MOIMCJOBJME > 22f)
                        {
                            CameraClassCopy.MOIMCJOBJME = 22f;
                        }
                        if (CameraClassCopy.CMHIKHJGAGD <= -62f && CameraClassCopy.CEKNDFGOILP < -62f)
                        {
                            CameraClassCopy.CEKNDFGOILP = -62f;
                        }
                        if (CameraClassCopy.CMHIKHJGAGD >= 62f && CameraClassCopy.CEKNDFGOILP > 62f)
                        {
                            CameraClassCopy.CEKNDFGOILP = 62f;
                        }
                    }
                    if (CameraClassCopy.CEKNDFGOILP < -62f)
                    {
                        CameraClassCopy.CEKNDFGOILP = -62f;
                    }
                    if (CameraClassCopy.CEKNDFGOILP > 62f)
                    {
                        CameraClassCopy.CEKNDFGOILP = 62f;
                    }
                }
                if (CameraClassCopy.CMHIKHJGAGD >= -19f && CameraClassCopy.CMHIKHJGAGD <= 19f)
                {
                    if (CameraClassCopy.CEKNDFGOILP < -19f || CameraClassCopy.CEKNDFGOILP > 19f)
                    {
                        if (CameraClassCopy.JBFIOOFDMND < -102f && CameraClassCopy.MOIMCJOBJME < -102f)
                        {
                            CameraClassCopy.MOIMCJOBJME = -102f;
                        }
                        if (CameraClassCopy.JBFIOOFDMND > 102f && CameraClassCopy.MOIMCJOBJME > 102f)
                        {
                            CameraClassCopy.MOIMCJOBJME = 102f;
                        }
                    }
                    if (CameraClassCopy.JBFIOOFDMND < -102f || CameraClassCopy.JBFIOOFDMND > 102f)
                    {
                        if (CameraClassCopy.CEKNDFGOILP < -19f)
                        {
                            CameraClassCopy.CEKNDFGOILP = -19f;
                        }
                        if (CameraClassCopy.CEKNDFGOILP > 19f)
                        {
                            CameraClassCopy.CEKNDFGOILP = 19f;
                        }
                    }
                }
                if (CameraClassCopy.MOIMCJOBJME > 102f || CameraClassCopy.MOIMCJOBJME < -102f)
                {
                    if (CameraClassCopy.CMHIKHJGAGD < -19f && CameraClassCopy.CEKNDFGOILP >= -19f)
                    {
                        CameraClassCopy.CEKNDFGOILP = -19f;
                    }
                    if (CameraClassCopy.CMHIKHJGAGD > 19f && CameraClassCopy.CEKNDFGOILP <= 19f)
                    {
                        CameraClassCopy.CEKNDFGOILP = 19f;
                    }
                }
            }
            if (World.location == 46)
            {
                if (CameraClassCopy.CMHIKHJGAGD < 99f && CameraClassCopy.BMFDFFLPBOJ >= 99f)
                {
                    if (CameraClassCopy.JBFIOOFDMND > -152f && CameraClassCopy.JBFIOOFDMND < 152f)
                    {
                        CameraClassCopy.MOIMCJOBJME = NAEEIFNFBBO.KBNMFKGMPMF(CameraClassCopy.MOIMCJOBJME, -56f, 56f);
                    }
                    if (CameraClassCopy.JBFIOOFDMND <= -152f && CameraClassCopy.MOIMCJOBJME > -152f)
                    {
                        CameraClassCopy.MOIMCJOBJME = -152f;
                    }
                    if (CameraClassCopy.JBFIOOFDMND >= 152f && CameraClassCopy.MOIMCJOBJME < 152f)
                    {
                        CameraClassCopy.MOIMCJOBJME = 152f;
                    }
                }
                if (CameraClassCopy.CMHIKHJGAGD >= 99f && CameraClassCopy.BMFDFFLPBOJ < 99f && (CameraClassCopy.NJDGEELLAKG < -56.5f || CameraClassCopy.NJDGEELLAKG > 56.5f))
                {
                    CameraClassCopy.CEKNDFGOILP = 99f;
                }
            }
            if (World.location == 47)
            {
                if (CameraClassCopy.JBFIOOFDMND < -80.5f || CameraClassCopy.JBFIOOFDMND > 80.5f)
                {
                    CameraClassCopy.CEKNDFGOILP = NAEEIFNFBBO.KBNMFKGMPMF(CameraClassCopy.CEKNDFGOILP, -13.5f, 13.5f);
                }
                if (CameraClassCopy.CMHIKHJGAGD < -80.5f || CameraClassCopy.CMHIKHJGAGD > 80.5f)
                {
                    CameraClassCopy.MOIMCJOBJME = NAEEIFNFBBO.KBNMFKGMPMF(CameraClassCopy.MOIMCJOBJME, -13.5f, 13.5f);
                }
            }
            if (World.location >= 50 && World.location <= 59 && CameraClassCopy.HLMAFBJHCIK < World.ground + 8f)
            {
                CameraClassCopy.HLMAFBJHCIK = World.ground + 8f;
            }
            if (World.BKMCFPJLNMJ(0) == 3 && NEGAFEHECNL.LODPJDDLEKI != 0 && CameraClassCopy.HLMAFBJHCIK < World.ground + 13f)
            {
                CameraClassCopy.HLMAFBJHCIK = World.ground + 13f;
            }
        }

        // Token: 0x0600000A RID: 10 RVA: 0x00003E88 File Offset: 0x00002088
        public static int OGACMNANIIM(DFOGOCNBECG OAAMGFLINOB)
        {
            int num = 0;
            if (OAAMGFLINOB.AHBNKMMMGFI > 0f)
            {
                if (OAAMGFLINOB.PLFGKLGCOMD == CameraClassCopy.NNMDEFLLNBF)
                {
                    num = 1;
                }
                if (FFCEGMEAIBP.LOBDMDPMFLK == 0 && OAAMGFLINOB.GOOKPABIPBC == Plugin.SecondPlayer)
                {
                    num = 1;
                }
                if (OAAMGFLINOB.PLFGKLGCOMD == NJBJIIIACEP.MLLALIOOPEP)
                {
                    num = 1;
                }
                if (CameraClassCopy.BPJFLJPKKJK == 6 && OAAMGFLINOB.PLFGKLGCOMD == NJBJIIIACEP.MLLALIOOPEP)
                {
                    num = 1;
                }
                if (CameraClassCopy.GMJKGKDFHOH >= 0)
                {
                    int num2 = 0;
                    if (OAAMGFLINOB.NLDPMDNKGIC == 50 && OAAMGFLINOB.NELODEMHJHN > 0 && HAPFAOIMGOL.OMOGPIJGMKO[OAAMGFLINOB.NELODEMHJHN].DHLGNKKPNMB == 0f)
                    {
                        num2 = 1;
                    }
                    if ((OAAMGFLINOB.KGELHDKDHFM() > 0 || (OAAMGFLINOB.FIEMGOLBHIO != 1 && OAAMGFLINOB.OOFFPCOALKB > 0f && num2 == 0) || FFCEGMEAIBP.LOBDMDPMFLK < 2 || OAAMGFLINOB.NLOOBNDGIKO.NNAGIMAACLN > 0f) && (OAAMGFLINOB.MGPDGDCIBGC == 0f || FFCEGMEAIBP.LOBDMDPMFLK != 2) && (OAAMGFLINOB.OJAJENJLBMF >= 0 || OAAMGFLINOB.FCOHFJHAFEH >= 0))
                    {
                        num = 1;
                    }
                }
                if (CameraClassCopy.GMJKGKDFHOH == 1 && CameraClassCopy.BPJFLJPKKJK != 6)
                {
                    if (FFCEGMEAIBP.OLJFOJOLLOM == 2 && FFCEGMEAIBP.LOBDMDPMFLK == 2)
                    {
                        if (OAAMGFLINOB.KGELHDKDHFM() > 0)
                        {
                            num = 1;
                        }
                    }
                    else if (FFCEGMEAIBP.LOBDMDPMFLK == 0 || FFCEGMEAIBP.LOBDMDPMFLK == 2)
                    {
                        for (int i = 1; i <= NJBJIIIACEP.NBBBLJDBLNM; i++)
                        {
                            DFOGOCNBECG dfogocnbecg = NJBJIIIACEP.OAAMGFLINOB[i];
                            if ((dfogocnbecg.OJAJENJLBMF >= 0 || dfogocnbecg.FCOHFJHAFEH >= 0) && dfogocnbecg.NNMDEFLLNBF > 0 && dfogocnbecg.NNMDEFLLNBF != dfogocnbecg.PLFGKLGCOMD && dfogocnbecg.NNMDEFLLNBF == OAAMGFLINOB.PLFGKLGCOMD)
                            {
                                num = 1;
                            }
                        }
                    }
                }
                if (CameraClassCopy.BPJFLJPKKJK != 6 && (CameraClassCopy.GMJKGKDFHOH >= 2 || CameraClassCopy.ODGCKCPJMJK == 0))
                {
                    if (FFCEGMEAIBP.LOBDMDPMFLK == 0)
                    {
                        num = 1;
                    }
                    if (OAAMGFLINOB.KGELHDKDHFM() > 0)
                    {
                        num = 1;
                    }
                    if (FFCEGMEAIBP.LOBDMDPMFLK < 0 && FFCEGMEAIBP.OOODPHNGHGD > 0 && OAAMGFLINOB.NEMJMNEGAAH(FFCEGMEAIBP.OOODPHNGHGD) > 0)
                    {
                        num = 1;
                    }
                }
                if (num > 0 && NJBJIIIACEP.MLLALIOOPEP > 0 && OAAMGFLINOB.PLFGKLGCOMD != NJBJIIIACEP.MLLALIOOPEP && (OAAMGFLINOB.OJAJENJLBMF < 0 || FFCEGMEAIBP.LOBDMDPMFLK == 0))
                {
                    DFOGOCNBECG dfogocnbecg2 = NJBJIIIACEP.OAAMGFLINOB[NJBJIIIACEP.MLLALIOOPEP];
                    if (NAEEIFNFBBO.FHPCDHIGILG(OAAMGFLINOB.NJDGEELLAKG, OAAMGFLINOB.BMFDFFLPBOJ, dfogocnbecg2.NJDGEELLAKG, dfogocnbecg2.BMFDFFLPBOJ) > CameraClassCopy.EHNKMGPGIBO())
                    {
                        num = 0;
                    }
                    if (World.location == 25 && OAAMGFLINOB.BMFDFFLPBOJ > World.camNorth)
                    {
                        num = 0;
                    }
                }
                if (OAAMGFLINOB.OJAJENJLBMF >= 0 && CameraClassCopy.ODGCKCPJMJK > 1 && (OAAMGFLINOB.NLOOBNDGIKO.PNGFDALFGLE >= 1f || OAAMGFLINOB.NLOOBNDGIKO.EMJMDDNMFFA >= 1f))
                {
                    num = 1;
                    OAAMGFLINOB.NLOOBNDGIKO.NNAGIMAACLN = 100f;
                }
            }
            if (LIPNHOMGGHF.FAKHAFKOBPB == 50 && FFCEGMEAIBP.LOBDMDPMFLK == 1 && FFCEGMEAIBP.LPBCEGPJNMF > 0 && CameraClassCopy.BPJFLJPKKJK != 6)
            {
                if (OAAMGFLINOB.NEMJMNEGAAH(FFCEGMEAIBP.LPBCEGPJNMF) == 0 || Mathf.Abs(FFCEGMEAIBP.NJPKCMBLMLG) == 1093)
                {
                    num = 0;
                }
                if (OAAMGFLINOB.PLFGKLGCOMD == FFCEGMEAIBP.LPBCEGPJNMF || (OAAMGFLINOB.OJAJENJLBMF >= 0 && OAAMGFLINOB.NEMJMNEGAAH(FFCEGMEAIBP.LPBCEGPJNMF) > 0))
                {
                    num = 1;
                }
            }
            if (LIPNHOMGGHF.FAKHAFKOBPB == 70)
            {
                num = 1;
            }
            return num;
        }

        // Token: 0x0600000B RID: 11 RVA: 0x0000419C File Offset: 0x0000239C
        public static void GMGLHLHLDGM(int GKNIAFAOLJK, int CBCBKBNCNCC = 70)
        {
            CameraClassCopy.NCCMNFNECKC = GKNIAFAOLJK;
            CameraClassCopy.COMOHLEACFP = (float)CBCBKBNCNCC;
        }

        // Token: 0x0600000C RID: 12 RVA: 0x000041AC File Offset: 0x000023AC
        public static void DIJBHIAAIOF(int JNCFFGOIJMF = 0)
        {
            CameraClassCopy.IGJHLDNPBPL = CameraClassCopy.NJDGEELLAKG;
            CameraClassCopy.DOEBJOGHIFL = CameraClassCopy.FNNBCDPJBIO;
            CameraClassCopy.IJPOGOBJCGN = CameraClassCopy.BMFDFFLPBOJ;
            if (LIPNHOMGGHF.FAKHAFKOBPB != 70)
            {
                CameraClassCopy.NNMDEFLLNBF = CameraClassCopy.JCKCCDKDEKP;
                CameraClassCopy.BPJFLJPKKJK = CameraClassCopy.ONOKPJKPEFL;
            }
            if (CameraClassCopy.COMOHLEACFP > 0f && CameraClassCopy.NCCMNFNECKC > 0 && CameraClassCopy.BPJFLJPKKJK != 6)
            {
                CameraClassCopy.COMOHLEACFP -= 2f * MBLIOKEDHHB.MCJHGEHEPMD;
                CameraClassCopy.NNMDEFLLNBF = CameraClassCopy.NCCMNFNECKC;
            }
            if (NEGAFEHECNL.LODPJDDLEKI != 0 && NEGAFEHECNL.NNMDEFLLNBF > 0 && (CameraClassCopy.BPJFLJPKKJK != 6 || LIPNHOMGGHF.FAKHAFKOBPB == 70) && (NEGAFEHECNL.IMJHCHECCED >= -15f || LIPNHOMGGHF.FAKHAFKOBPB == 70 || FFCEGMEAIBP.LOBDMDPMFLK == 0))
            {
                CameraClassCopy.NNMDEFLLNBF = NEGAFEHECNL.NNMDEFLLNBF;
                if (CameraClassCopy.BPJFLJPKKJK != 7)
                {
                    CameraClassCopy.BPJFLJPKKJK = -1;
                }
            }
            if (LIPNHOMGGHF.FAKHAFKOBPB == 50 && FFCEGMEAIBP.LOBDMDPMFLK == 0 && CameraClassCopy.PMELGMJHBPC > 0 && CameraClassCopy.LAMPIGLOGDP > 0f)
            {
                CameraClassCopy.NNMDEFLLNBF = NJBJIIIACEP.MLLALIOOPEP;
                CameraClassCopy.BPJFLJPKKJK = CameraClassCopy.PMELGMJHBPC;
                CameraClassCopy.LAMPIGLOGDP -= 1f * MBLIOKEDHHB.MCJHGEHEPMD;
                if (CameraClassCopy.LAMPIGLOGDP <= 0f)
                {
                    CameraClassCopy.PMELGMJHBPC = 0;
                }
            }
            if (LIPNHOMGGHF.FAKHAFKOBPB < 0)
            {
                CameraClassCopy.NNMDEFLLNBF = 1;
                CameraClassCopy.BPJFLJPKKJK = 0;
            }
            CameraClassCopy.ODGCKCPJMJK = 0;
            if (LIPNHOMGGHF.FAKHAFKOBPB == 50)
            {
                for (int i = 1; i <= NJBJIIIACEP.NBBBLJDBLNM; i++)
                {
                    DFOGOCNBECG dfogocnbecg = NJBJIIIACEP.OAAMGFLINOB[i];
                    if ((dfogocnbecg.KGELHDKDHFM() > 0 || FFCEGMEAIBP.LOBDMDPMFLK < 2) && dfogocnbecg.AHBNKMMMGFI > 0f && (dfogocnbecg.OJAJENJLBMF >= 0 || dfogocnbecg.FCOHFJHAFEH >= 0))
                    {
                        CameraClassCopy.ODGCKCPJMJK++;
                    }
                }
            }
            float num = 0f;
            CameraClassCopy.OGCNMOGKCPE = 25f * CameraClassCopy.JHGPIHNAADD;
            if (CameraClassCopy.NNMDEFLLNBF == 0)
            {
                CameraClassCopy.JBFIOOFDMND = 0f;
                CameraClassCopy.IKLMALGHGFI = 0f;
                CameraClassCopy.CMHIKHJGAGD = 0f;
                int num2 = 0;
                int num3 = 0;
                int num4 = 0;
                float num5 = 0f;
                for (int i = 1; i <= NJBJIIIACEP.NBBBLJDBLNM; i++)
                {
                    DFOGOCNBECG dfogocnbecg = NJBJIIIACEP.OAAMGFLINOB[i];
                    if (CameraClassCopy.OGACMNANIIM(dfogocnbecg) > 0)
                    {
                        num += 1f;
                        if (num2 != NJBJIIIACEP.MLLALIOOPEP)
                        {
                            num2 = i;
                        }
                        if (CameraClassCopy.BPJFLJPKKJK == -1)
                        {
                            CameraClassCopy.IKLMALGHGFI += dfogocnbecg.DFINJNKKMFL(3) - 2f;
                        }
                        else
                        {
                            CameraClassCopy.IKLMALGHGFI += dfogocnbecg.FNNBCDPJBIO + 9f * dfogocnbecg.JNLAJNFCDHA;
                        }
                        CameraClassCopy.JBFIOOFDMND += dfogocnbecg.NJDGEELLAKG;
                        CameraClassCopy.CMHIKHJGAGD += dfogocnbecg.BMFDFFLPBOJ;
                        float num6 = NAEEIFNFBBO.FHPCDHIGILG(dfogocnbecg.NJDGEELLAKG, dfogocnbecg.BMFDFFLPBOJ, 0f, 0f);
                        if (num6 > num5)
                        {
                            num5 = num6;
                            num3 = i;
                        }
                    }
                }
                if (num == 0f && World.ringShape > 0)
                {
                    CameraClassCopy.IKLMALGHGFI += World.ringGround;
                }
                if (num > 1f)
                {
                    CameraClassCopy.JBFIOOFDMND /= num;
                    CameraClassCopy.IKLMALGHGFI /= num;
                    CameraClassCopy.CMHIKHJGAGD /= num;
                    if (LIPNHOMGGHF.FAKHAFKOBPB == 50 && CameraClassCopy.ODGCKCPJMJK <= 1)
                    {
                        DFOGOCNBECG dfogocnbecg2 = NJBJIIIACEP.OAAMGFLINOB[NJBJIIIACEP.MLLALIOOPEP];
                        if (NAEEIFNFBBO.FHPCDHIGILG(CameraClassCopy.NJDGEELLAKG, CameraClassCopy.BMFDFFLPBOJ, dfogocnbecg2.NJDGEELLAKG, dfogocnbecg2.BMFDFFLPBOJ) < NAEEIFNFBBO.FHPCDHIGILG(CameraClassCopy.NJDGEELLAKG, CameraClassCopy.BMFDFFLPBOJ, CameraClassCopy.JBFIOOFDMND, CameraClassCopy.CMHIKHJGAGD))
                        {
                            CameraClassCopy.JBFIOOFDMND = Mathf.Lerp(CameraClassCopy.JBFIOOFDMND, dfogocnbecg2.NJDGEELLAKG, 0.5f);
                            CameraClassCopy.CMHIKHJGAGD = Mathf.Lerp(CameraClassCopy.CMHIKHJGAGD, dfogocnbecg2.BMFDFFLPBOJ, 0.5f);
                        }
                    }
                }
                if (num > 1f && CameraClassCopy.BPJFLJPKKJK != 6)
                {
                    num5 = 0f;
                    for (int i = 1; i <= NJBJIIIACEP.NBBBLJDBLNM; i++)
                    {
                        DFOGOCNBECG dfogocnbecg = NJBJIIIACEP.OAAMGFLINOB[i];
                        if (CameraClassCopy.OGACMNANIIM(dfogocnbecg) > 0 && i != num3)
                        {
                            float num6 = NAEEIFNFBBO.FHPCDHIGILG(dfogocnbecg.NJDGEELLAKG, dfogocnbecg.BMFDFFLPBOJ, NJBJIIIACEP.OAAMGFLINOB[num3].NJDGEELLAKG, NJBJIIIACEP.OAAMGFLINOB[num3].BMFDFFLPBOJ);
                            if (num6 > num5)
                            {
                                num5 = num6;
                                num4 = i;
                            }
                        }
                    }
                    if (num3 > 0 && num4 > 0)
                    {
                        CameraClassCopy.FKBDCLLANMK = NAEEIFNFBBO.IBHAGKMAKLE(NJBJIIIACEP.OAAMGFLINOB[num3].NJDGEELLAKG, NJBJIIIACEP.OAAMGFLINOB[num3].BMFDFFLPBOJ, NJBJIIIACEP.OAAMGFLINOB[num4].NJDGEELLAKG, NJBJIIIACEP.OAAMGFLINOB[num4].BMFDFFLPBOJ);
                        CameraClassCopy.OGCNMOGKCPE = NAEEIFNFBBO.FHPCDHIGILG(NJBJIIIACEP.OAAMGFLINOB[num3].NJDGEELLAKG, NJBJIIIACEP.OAAMGFLINOB[num3].BMFDFFLPBOJ, NJBJIIIACEP.OAAMGFLINOB[num4].NJDGEELLAKG, NJBJIIIACEP.OAAMGFLINOB[num4].BMFDFFLPBOJ);
                        CameraClassCopy.OGCNMOGKCPE *= 0.9f;
                        if (CameraClassCopy.OGCNMOGKCPE < 25f)
                        {
                            CameraClassCopy.OGCNMOGKCPE = 25f;
                        }
                        if (CameraClassCopy.OGCNMOGKCPE > 50f)
                        {
                            CameraClassCopy.OGCNMOGKCPE = 50f;
                        }
                        CameraClassCopy.OGCNMOGKCPE *= CameraClassCopy.JHGPIHNAADD;
                    }
                }
                else
                {
                    CameraClassCopy.NNMDEFLLNBF = num2;
                }
                if (CameraClassCopy.BPJFLJPKKJK == 6)
                {
                    CameraClassCopy.NNMDEFLLNBF = num2;
                }
            }
            if (GIMNNPMAKNJ.DGINJFACEDM == 2)
            {
                CameraClassCopy.OGCNMOGKCPE *= 0.75f;
                if (CameraClassCopy.OGCNMOGKCPE < 25f)
                {
                    CameraClassCopy.OGCNMOGKCPE = 25f;
                }
            }
            if (CameraClassCopy.NNMDEFLLNBF > 0 && CameraClassCopy.BPJFLJPKKJK != 6)
            {
                DFOGOCNBECG dfogocnbecg = NJBJIIIACEP.OAAMGFLINOB[CameraClassCopy.NNMDEFLLNBF];
                CameraClassCopy.JBFIOOFDMND = dfogocnbecg.NJDGEELLAKG;
                CameraClassCopy.CMHIKHJGAGD = dfogocnbecg.BMFDFFLPBOJ;
                CameraClassCopy.IKLMALGHGFI = dfogocnbecg.FNNBCDPJBIO + 9f * dfogocnbecg.JNLAJNFCDHA;
                if (CameraClassCopy.BPJFLJPKKJK >= 0)
                {
                    int num7 = dfogocnbecg.KFHGMKAKGDC();
                    float num8 = NAEEIFNFBBO.FHPCDHIGILG(CameraClassCopy.NJDGEELLAKG, CameraClassCopy.BMFDFFLPBOJ, CameraClassCopy.JBFIOOFDMND, CameraClassCopy.CMHIKHJGAGD);
                    if (num8 < 15f && (num7 == 1 || num7 == 2))
                    {
                        CameraClassCopy.IKLMALGHGFI += (15f - num8) * 0.4f;
                    }
                    if (num7 >= 2 || dfogocnbecg.AJBJHOMKGOE != 0)
                    {
                        CameraClassCopy.IKLMALGHGFI -= 1f * dfogocnbecg.JNLAJNFCDHA;
                    }
                    if (num7 >= 3 || dfogocnbecg.AJBJHOMKGOE != 0)
                    {
                        CameraClassCopy.IKLMALGHGFI -= 1f * dfogocnbecg.JNLAJNFCDHA;
                    }
                    if (num7 >= 4 || dfogocnbecg.AJBJHOMKGOE != 0)
                    {
                        CameraClassCopy.IKLMALGHGFI -= 1f * dfogocnbecg.JNLAJNFCDHA;
                    }
                }
                if (CameraClassCopy.BPJFLJPKKJK == -1)
                {
                    CameraClassCopy.JBFIOOFDMND = dfogocnbecg.EMKLFKIAFLF(3);
                    CameraClassCopy.CMHIKHJGAGD = dfogocnbecg.KNEIMEMEAGP(3);
                    CameraClassCopy.IKLMALGHGFI = dfogocnbecg.DFINJNKKMFL(3) - 2f;
                }
                if (dfogocnbecg.NLDPMDNKGIC == 73 && dfogocnbecg.FOLKELMDDHF == 1)
                {
                    CameraClassCopy.IKLMALGHGFI += 3f * (1f / dfogocnbecg.JNLAJNFCDHA);
                }
                CameraClassCopy.FKBDCLLANMK = dfogocnbecg.MPFFANIIEDG;
                if (FFCEGMEAIBP.LOBDMDPMFLK == 0 && LIPNHOMGGHF.CMOMBJMMOBK == 0f)
                {
                    if (CameraClassCopy.BPJFLJPKKJK == 1)
                    {
                        CameraClassCopy.GAEDKFPPAHF = dfogocnbecg.MPFFANIIEDG;
                        if (GIMNNPMAKNJ.DGINJFACEDM == 1 && dfogocnbecg.BMFDFFLPBOJ > -20f)
                        {
                            CameraClassCopy.GAEDKFPPAHF = 180f;
                        }
                    }
                    while (NAEEIFNFBBO.FHPCDHIGILG(CameraClassCopy.NJDGEELLAKG, CameraClassCopy.BMFDFFLPBOJ, dfogocnbecg.NJDGEELLAKG, dfogocnbecg.BMFDFFLPBOJ) < 15f)
                    {
                        CameraClassCopy.NJDGEELLAKG += NAEEIFNFBBO.PDOBPEFCMCK(CameraClassCopy.GAEDKFPPAHF, 1f);
                        CameraClassCopy.BMFDFFLPBOJ += NAEEIFNFBBO.GPMMBFPCFFL(CameraClassCopy.GAEDKFPPAHF, 1f);
                    }
                }
            }
            if (LIPNHOMGGHF.FAKHAFKOBPB == 50 && CameraClassCopy.BPJFLJPKKJK == 1 && CameraClassCopy.BKLMPJIODMA > 0f)
            {
                DFOGOCNBECG dfogocnbecg;
                if (CameraClassCopy.NNMDEFLLNBF > 0)
                {
                    dfogocnbecg = NJBJIIIACEP.OAAMGFLINOB[CameraClassCopy.NNMDEFLLNBF];
                }
                else
                {
                    dfogocnbecg = NJBJIIIACEP.OAAMGFLINOB[NJBJIIIACEP.MLLALIOOPEP];
                }
                if (((dfogocnbecg.NLDPMDNKGIC >= 1501 && dfogocnbecg.NLDPMDNKGIC < 1600) || (dfogocnbecg.LMMJLINJJHA >= 1501 && dfogocnbecg.LMMJLINJJHA < 1600 && dfogocnbecg.EIFKGNIOGKH > 0 && dfogocnbecg.DAEJMKKNCMI != 10)) && NAEEIFNFBBO.OOALBELFICL(dfogocnbecg.LPDBCDCGIEI, CameraClassCopy.AAPMLHAGBGF) <= 45f && CameraClassCopy.BKLMPJIODMA < 16f)
                {
                    CameraClassCopy.BKLMPJIODMA = 16f;
                }
                if (CameraClassCopy.BKLMPJIODMA > 1f)
                {
                    CameraClassCopy.JBFIOOFDMND = dfogocnbecg.NJDGEELLAKG + NAEEIFNFBBO.PDOBPEFCMCK(dfogocnbecg.MPFFANIIEDG, 10f);
                    CameraClassCopy.CMHIKHJGAGD = dfogocnbecg.BMFDFFLPBOJ + NAEEIFNFBBO.GPMMBFPCFFL(dfogocnbecg.MPFFANIIEDG, 10f);
                    CameraClassCopy.IKLMALGHGFI = (CameraClassCopy.IKLMALGHGFI + dfogocnbecg.DFINJNKKMFL(3)) / 2f;
                    CameraClassCopy.FKBDCLLANMK = CameraClassCopy.HEJMJEKNCND(dfogocnbecg.MPFFANIIEDG - 145f, dfogocnbecg.MPFFANIIEDG + 145f, -1f, -1f);
                    CameraClassCopy.GAEDKFPPAHF = CameraClassCopy.FKBDCLLANMK;
                    CameraClassCopy.OGCNMOGKCPE /= 2f;
                    CameraClassCopy.EODCNMAEOGE = Mathf.MoveTowards(CameraClassCopy.EODCNMAEOGE, 0.5f, 0.02f * MBLIOKEDHHB.MCJHGEHEPMD);
                    if (dfogocnbecg.NLDPMDNKGIC != 1500 && dfogocnbecg.LMMJLINJJHA != 1500)
                    {
                        CameraClassCopy.BKLMPJIODMA = Mathf.MoveTowards(CameraClassCopy.BKLMPJIODMA, 1f, MBLIOKEDHHB.MCJHGEHEPMD);
                    }
                }
            }
            CameraClassCopy.BPBKHCABOMM = 0.05f;
            CameraClassCopy.GDIHABOEHCD = 0.02f;
            CameraClassCopy.GCDFHFMNGID = 0.5f;
            if (LIPNHOMGGHF.FAKHAFKOBPB == 50 && NEGAFEHECNL.LODPJDDLEKI == 0)
            {
                CameraClassCopy.GCDFHFMNGID *= 2f;
            }
            if (LIPNHOMGGHF.FAKHAFKOBPB == 70)
            {
                CameraClassCopy.BPBKHCABOMM /= 2f;
            }
            if (CameraClassCopy.BPJFLJPKKJK == 5)
            {
                CameraClassCopy.BPBKHCABOMM *= 2f;
            }
            if (CameraClassCopy.BPJFLJPKKJK == 6)
            {
                CameraClassCopy.BPBKHCABOMM = 0.25f;
            }
            if (CameraClassCopy.NNMDEFLLNBF > 0 && CameraClassCopy.BPJFLJPKKJK != 6)
            {
                if (NJBJIIIACEP.OAAMGFLINOB[CameraClassCopy.NNMDEFLLNBF].NLDPMDNKGIC == 10 && NJBJIIIACEP.OAAMGFLINOB[CameraClassCopy.NNMDEFLLNBF].NHBNHGOGIJM != 0f)
                {
                    CameraClassCopy.BPBKHCABOMM *= 2f;
                }
                if (NJBJIIIACEP.OAAMGFLINOB[CameraClassCopy.NNMDEFLLNBF].AJBJHOMKGOE > 0 && OMKJKGHCKII.DEFDNDGEDJH[NJBJIIIACEP.OAAMGFLINOB[CameraClassCopy.NNMDEFLLNBF].AJBJHOMKGOE].NLDPMDNKGIC == 2)
                {
                    CameraClassCopy.BPBKHCABOMM *= 2f;
                }
            }
            CameraClassCopy.BPBKHCABOMM *= MBLIOKEDHHB.MCJHGEHEPMD;
            if (JNCFFGOIJMF > 0 || (FFCEGMEAIBP.LOBDMDPMFLK == 0 && LIPNHOMGGHF.CMOMBJMMOBK == 0f))
            {
                CameraClassCopy.BPBKHCABOMM = 1f;
            }
            CameraClassCopy.KJOEMPCDGGD = Mathf.Lerp(CameraClassCopy.KJOEMPCDGGD, CameraClassCopy.JBFIOOFDMND, CameraClassCopy.BPBKHCABOMM);
            CameraClassCopy.GJGODIJIOKG = Mathf.Lerp(CameraClassCopy.GJGODIJIOKG, CameraClassCopy.IKLMALGHGFI, CameraClassCopy.BPBKHCABOMM);
            CameraClassCopy.JOEOOOKAFDD = Mathf.Lerp(CameraClassCopy.JOEOOOKAFDD, CameraClassCopy.CMHIKHJGAGD, CameraClassCopy.BPBKHCABOMM);
            if (LIPNHOMGGHF.FAKHAFKOBPB == 70)
            {
                CameraClassCopy.GDIHABOEHCD /= 2f;
            }
            if (CameraClassCopy.BPJFLJPKKJK != 0 && CameraClassCopy.BPJFLJPKKJK != 6 && CameraClassCopy.BPJFLJPKKJK != 7 && CameraClassCopy.GIBHLNFEPKE == 0f)
            {
                CameraClassCopy.MOIMCJOBJME = CameraClassCopy.KJOEMPCDGGD;
                CameraClassCopy.HLMAFBJHCIK = CameraClassCopy.GJGODIJIOKG;
                CameraClassCopy.CEKNDFGOILP = CameraClassCopy.JOEOOOKAFDD;
                float num9 = NAEEIFNFBBO.FHPCDHIGILG(CameraClassCopy.NJDGEELLAKG, CameraClassCopy.BMFDFFLPBOJ, CameraClassCopy.KJOEMPCDGGD, CameraClassCopy.JOEOOOKAFDD);
                float num10 = CameraClassCopy.OGCNMOGKCPE;
                if (num10 > num9 && CameraClassCopy.BPJFLJPKKJK != 5)
                {
                    num10 = num9;
                }
                CameraClassCopy.HLMAFBJHCIK += num10 * (CameraClassCopy.AMMOCBAOABP - 0.1f);
                if (CameraClassCopy.BPJFLJPKKJK == 1 && CameraClassCopy.BKLMPJIODMA <= 1f)
                {
                    CameraClassCopy.FKBDCLLANMK = CameraClassCopy.HEJMJEKNCND(CameraClassCopy.FKBDCLLANMK, CameraClassCopy.FKBDCLLANMK + 180f, -1f, -1f);
                    if (CameraClassCopy.NNMDEFLLNBF > 0 && CameraClassCopy.BKLMPJIODMA <= 1f)
                    {
                        DFOGOCNBECG dfogocnbecg = NJBJIIIACEP.OAAMGFLINOB[CameraClassCopy.NNMDEFLLNBF];
                        if (FFCEGMEAIBP.LOBDMDPMFLK == 0 || dfogocnbecg.NNMDEFLLNBF == 0 || NJBJIIIACEP.OAAMGFLINOB[dfogocnbecg.NNMDEFLLNBF].OJAJENJLBMF < 0)
                        {
                            CameraClassCopy.FKBDCLLANMK = dfogocnbecg.MPFFANIIEDG + 180f;
                            CameraClassCopy.GCDFHFMNGID *= 2f;
                            CameraClassCopy.GDIHABOEHCD *= 2f;
                            if (dfogocnbecg.LMMJLINJJHA != 0 && dfogocnbecg.DAEJMKKNCMI == 10)
                            {
                                CameraClassCopy.FKBDCLLANMK -= dfogocnbecg.MMILEMJGHPI(dfogocnbecg.LMMJLINJJHA);
                            }
                            if (dfogocnbecg.NLDPMDNKGIC == 50)
                            {
                                if (dfogocnbecg.NELODEMHJHN <= 0)
                                {
                                    CameraClassCopy.FKBDCLLANMK = dfogocnbecg.MPFFANIIEDG;
                                }
                                if (dfogocnbecg.NELODEMHJHN < 0 && dfogocnbecg.OHLENIHCHAP > 0 && (World.location == 17 || World.location == 27))
                                {
                                    CameraClassCopy.FKBDCLLANMK = dfogocnbecg.MPFFANIIEDG + 180f;
                                }
                                if (dfogocnbecg.NELODEMHJHN > 0)
                                {
                                    GGKBLABCJFN ggkblabcjfn = HAPFAOIMGOL.OMOGPIJGMKO[dfogocnbecg.NELODEMHJHN];
                                    if (ggkblabcjfn.DHLGNKKPNMB == 0f)
                                    {
                                        if (ggkblabcjfn.NONJIHAJAKC == "Toilet")
                                        {
                                            CameraClassCopy.FKBDCLLANMK = dfogocnbecg.MPFFANIIEDG;
                                        }
                                        else
                                        {
                                            CameraClassCopy.FKBDCLLANMK = CameraClassCopy.HEJMJEKNCND(dfogocnbecg.MPFFANIIEDG - 135f, dfogocnbecg.MPFFANIIEDG + 135f, -1f, -1f);
                                        }
                                        CameraClassCopy.OGCNMOGKCPE /= 2f;
                                    }
                                    else if (NAEEIFNFBBO.OOALBELFICL(ggkblabcjfn.AAPMLHAGBGF, ggkblabcjfn.PJJFOALHEPF) > 90f)
                                    {
                                        CameraClassCopy.FKBDCLLANMK = dfogocnbecg.MPFFANIIEDG;
                                    }
                                }
                            }
                            if (dfogocnbecg.NLDPMDNKGIC == 87 || dfogocnbecg.LMMJLINJJHA == 87 || dfogocnbecg.NLDPMDNKGIC == 948 || (dfogocnbecg.NLDPMDNKGIC == 54 && dfogocnbecg.FDNLACJLCHP > 0))
                            {
                                CameraClassCopy.FKBDCLLANMK = dfogocnbecg.MPFFANIIEDG;
                                CameraClassCopy.OGCNMOGKCPE *= 0.75f;
                            }
                            if (dfogocnbecg.NLDPMDNKGIC == 52 || dfogocnbecg.NLDPMDNKGIC == 151 || dfogocnbecg.NLDPMDNKGIC == 155)
                            {
                                CameraClassCopy.FKBDCLLANMK = CameraClassCopy.HEJMJEKNCND(dfogocnbecg.MPFFANIIEDG - 135f, dfogocnbecg.MPFFANIIEDG + 135f, -1f, -1f);
                                CameraClassCopy.OGCNMOGKCPE /= 2f;
                            }
                        }
                    }
                }
                if (CameraClassCopy.BPJFLJPKKJK == 2)
                {
                    CameraClassCopy.FKBDCLLANMK = CameraClassCopy.HEJMJEKNCND(CameraClassCopy.FKBDCLLANMK - 90f, CameraClassCopy.FKBDCLLANMK + 90f, -1f, -1f);
                }
                if (CameraClassCopy.BPJFLJPKKJK == 3)
                {
                    if (World.location <= 1)
                    {
                        CameraClassCopy.FKBDCLLANMK = CameraClassCopy.HEJMJEKNCND(180f, 90f, 270f, -1f);
                    }
                    if (World.location == 2)
                    {
                        CameraClassCopy.FKBDCLLANMK = CameraClassCopy.HEJMJEKNCND(0f, 90f, 270f, -1f);
                    }
                    if (World.location > 2)
                    {
                        CameraClassCopy.FKBDCLLANMK = CameraClassCopy.HEJMJEKNCND(0f, 180f, 90f, 270f);
                    }
                    CameraClassCopy.GAEDKFPPAHF = CameraClassCopy.FKBDCLLANMK;
                    CameraClassCopy.GDIHABOEHCD *= 2f;
                }
                if (CameraClassCopy.BPJFLJPKKJK == 4)
                {
                    CameraClassCopy.FKBDCLLANMK = CameraClassCopy.HEJMJEKNCND(45f, 225f, 135f, 315f);
                    CameraClassCopy.GAEDKFPPAHF = CameraClassCopy.FKBDCLLANMK;
                    CameraClassCopy.GDIHABOEHCD *= 2f;
                }
                if (CameraClassCopy.BPJFLJPKKJK == 5)
                {
                    CameraClassCopy.HLMAFBJHCIK += 35f;
                    CameraClassCopy.OGCNMOGKCPE = 0f;
                    CameraClassCopy.FKBDCLLANMK = 180f;
                    CameraClassCopy.GDIHABOEHCD *= 10f;
                }
                if (CameraClassCopy.BPJFLJPKKJK == -1 && CameraClassCopy.NNMDEFLLNBF > 0)
                {
                    CameraClassCopy.FKBDCLLANMK = CameraClassCopy.HEJMJEKNCND(NJBJIIIACEP.OAAMGFLINOB[CameraClassCopy.NNMDEFLLNBF].MPFFANIIEDG - 45f, NJBJIIIACEP.OAAMGFLINOB[CameraClassCopy.NNMDEFLLNBF].MPFFANIIEDG + 45f, -1f, -1f);
                    CameraClassCopy.GAEDKFPPAHF = CameraClassCopy.FKBDCLLANMK;
                    CameraClassCopy.OGCNMOGKCPE = 16f;
                    CameraClassCopy.HLMAFBJHCIK = CameraClassCopy.GJGODIJIOKG;
                    if (World.location == 21)
                    {
                        CameraClassCopy.OGCNMOGKCPE += 5f;
                        if (CameraClassCopy.NJDGEELLAKG > -15f && CameraClassCopy.NJDGEELLAKG < 15f && CameraClassCopy.HLMAFBJHCIK < 18f)
                        {
                            CameraClassCopy.HLMAFBJHCIK = 18f;
                        }
                    }
                }
                if (CameraClassCopy.NNMDEFLLNBF > 0 && NJBJIIIACEP.OAAMGFLINOB[CameraClassCopy.NNMDEFLLNBF].NELODEMHJHN > 0 && NJBJIIIACEP.OAAMGFLINOB[CameraClassCopy.NNMDEFLLNBF].OHLENIHCHAP > 0 && HAPFAOIMGOL.OMOGPIJGMKO[NJBJIIIACEP.OAAMGFLINOB[CameraClassCopy.NNMDEFLLNBF].NELODEMHJHN].DHLGNKKPNMB != 0f)
                {
                    if (CameraClassCopy.BPJFLJPKKJK == 5)
                    {
                        CameraClassCopy.HLMAFBJHCIK *= 1.5f;
                    }
                    else
                    {
                        CameraClassCopy.OGCNMOGKCPE *= 1.25f;
                    }
                }
                if (JNCFFGOIJMF > 0)
                {
                    CameraClassCopy.GAEDKFPPAHF = CameraClassCopy.FKBDCLLANMK;
                }
                else if (CameraClassCopy.LCKFFGMJIKG > 0f)
                {
                    CameraClassCopy.GAEDKFPPAHF = Mathf.LerpAngle(CameraClassCopy.GAEDKFPPAHF, CameraClassCopy.FKBDCLLANMK, CameraClassCopy.GCDFHFMNGID / 4f * MBLIOKEDHHB.MCJHGEHEPMD);
                }
                else
                {
                    CameraClassCopy.GAEDKFPPAHF = Mathf.MoveTowardsAngle(CameraClassCopy.GAEDKFPPAHF, CameraClassCopy.FKBDCLLANMK, CameraClassCopy.GCDFHFMNGID * MBLIOKEDHHB.MCJHGEHEPMD);
                }
                CameraClassCopy.MOIMCJOBJME += NAEEIFNFBBO.PDOBPEFCMCK(CameraClassCopy.GAEDKFPPAHF, CameraClassCopy.OGCNMOGKCPE);
                CameraClassCopy.CEKNDFGOILP += NAEEIFNFBBO.GPMMBFPCFFL(CameraClassCopy.GAEDKFPPAHF, CameraClassCopy.OGCNMOGKCPE);
                int bpjfljpkkjk = CameraClassCopy.BPJFLJPKKJK;
            }
            if (CameraClassCopy.BPJFLJPKKJK == 7)
            {
                Vector3 vector = new Vector3(0f, 0f, 0f);
                if (World.location <= 1)
                {
                    vector = CameraClassCopy.OOAMFDCLFMG(new Vector3(CameraClassCopy.NJDGEELLAKG, CameraClassCopy.FNNBCDPJBIO, CameraClassCopy.BMFDFFLPBOJ), new Vector3(-18f, 14f, 58f), new Vector3(58f, 14f, 0f), new Vector3(0f, 14f, -58f), new Vector3(-58f, 14f, 0f));
                }
                if (World.location == 22)
                {
                    vector = CameraClassCopy.OOAMFDCLFMG(new Vector3(CameraClassCopy.NJDGEELLAKG, CameraClassCopy.FNNBCDPJBIO, CameraClassCopy.BMFDFFLPBOJ), new Vector3(50f, 50f, 50f), new Vector3(50f, 50f, -50f), new Vector3(-50f, 50f, -50f), new Vector3(-50f, 50f, 50f));
                }
                if (GIMNNPMAKNJ.DGINJFACEDM == 1)
                {
                    vector = CameraClassCopy.OOAMFDCLFMG(new Vector3(CameraClassCopy.NJDGEELLAKG, CameraClassCopy.FNNBCDPJBIO, CameraClassCopy.BMFDFFLPBOJ), new Vector3(-54f, World.ceiling * 0.9f, World.camSouth), new Vector3(53f, World.ceiling * 0.9f, World.camSouth), new Vector3(-77f, World.ceiling * 0.9f, 75f), new Vector3(76f, World.ceiling * 0.9f, 75f));
                }
                if (GIMNNPMAKNJ.DGINJFACEDM == 2)
                {
                    vector = CameraClassCopy.OOAMFDCLFMG(new Vector3(CameraClassCopy.NJDGEELLAKG, CameraClassCopy.FNNBCDPJBIO, CameraClassCopy.BMFDFFLPBOJ), new Vector3(19f, World.ceiling * 0.9f, World.camEast), new Vector3(-19f, World.ceiling * 0.9f, World.camEast), new Vector3(-19f, World.ceiling * 0.9f, World.camWest), new Vector3(19f, World.ceiling * 0.9f, World.camWest));
                }
                if (GIMNNPMAKNJ.DGINJFACEDM == 4)
                {
                    vector = CameraClassCopy.OOAMFDCLFMG(new Vector3(CameraClassCopy.NJDGEELLAKG, CameraClassCopy.FNNBCDPJBIO, CameraClassCopy.BMFDFFLPBOJ), new Vector3(-102f, World.ceiling * 0.9f, -62f), new Vector3(-102f, World.ceiling * 0.9f, 62f), new Vector3(102f, World.ceiling * 0.9f, 62f), new Vector3(102f, World.ceiling * 0.9f, -62f));
                }
                if (World.location >= 2 && World.location != 22 && GIMNNPMAKNJ.DGINJFACEDM == 0)
                {
                    vector = CameraClassCopy.OOAMFDCLFMG(new Vector3(CameraClassCopy.NJDGEELLAKG, CameraClassCopy.FNNBCDPJBIO, CameraClassCopy.BMFDFFLPBOJ), new Vector3(World.camNorth, World.ceiling * 0.9f, World.camEast), new Vector3(World.camSouth, World.ceiling * 0.9f, World.camEast), new Vector3(World.camSouth, World.ceiling * 0.9f, World.camWest), new Vector3(World.camNorth, World.ceiling * 0.9f, World.camWest));
                }
                CameraClassCopy.MOIMCJOBJME = vector.x;
                CameraClassCopy.HLMAFBJHCIK = vector.y;
                CameraClassCopy.CEKNDFGOILP = vector.z;
                CameraClassCopy.GDIHABOEHCD *= 2f;
            }
            if (CameraClassCopy.GIBHLNFEPKE > 0f)
            {
                CameraClassCopy.GIBHLNFEPKE += MBLIOKEDHHB.MCJHGEHEPMD;
            }
            if (CameraClassCopy.GIBHLNFEPKE > 60f)
            {
                CameraClassCopy.GIBHLNFEPKE = 0f;
                CameraClassCopy.EODCNMAEOGE = 0f;
            }
            if (LIPNHOMGGHF.GCJKOBOBIGA == 0 && LIPNHOMGGHF.ANFMAHGLGJN > 15)
            {
                if (NAEEIFNFBBO.GAABAPFHBPM <= 1 && HKJOAJOKOIJ.LKCNKOJGIPD == 0)
                {
                    if (HKJOAJOKOIJ.EOOBMIDCKIF > 0f && HKJOAJOKOIJ.OLGCBGHOKDA > (float)Screen.width * 0.25f && HKJOAJOKOIJ.OLGCBGHOKDA < (float)Screen.width * 0.75f && HKJOAJOKOIJ.NAHLPJKCPAO > (float)Screen.height * 0.3f && HKJOAJOKOIJ.NAHLPJKCPAO < (float)Screen.height * 0.7f)
                    {
                        if (HKJOAJOKOIJ.ICBHMPFMKEJ != 0f)
                        {
                            CameraClassCopy.IFPJBJLEEDB = -HKJOAJOKOIJ.ICBHMPFMKEJ * 0.9f;
                            CameraClassCopy.GIBHLNFEPKE = 1f;
                        }
                        if (HKJOAJOKOIJ.HBAJMBGLBJB != 0f)
                        {
                            CameraClassCopy.LHBKHGBDPLH = -HKJOAJOKOIJ.HBAJMBGLBJB * 0.8f;
                            CameraClassCopy.GIBHLNFEPKE = 1f;
                        }
                    }
                    if (HKJOAJOKOIJ.MDJNMIJLGFF != 0f)
                    {
                        CameraClassCopy.KHKIEPDJELK = HKJOAJOKOIJ.MDJNMIJLGFF * 2f;
                        CameraClassCopy.GIBHLNFEPKE = 1f;
                    }
                }
                else if (HKJOAJOKOIJ.EOOBMIDCKIF > 0f && HKJOAJOKOIJ.OLGCBGHOKDA > (float)Screen.width * 0.35f && HKJOAJOKOIJ.OLGCBGHOKDA < (float)Screen.width * 0.65f && HKJOAJOKOIJ.NAHLPJKCPAO > (float)Screen.height * 0.35f && HKJOAJOKOIJ.NAHLPJKCPAO < (float)Screen.height * 0.65f && CameraClassCopy.FIJILHEFHIK(HKJOAJOKOIJ.OLGCBGHOKDA, HKJOAJOKOIJ.NAHLPJKCPAO) && HKJOAJOKOIJ.MMNNBOJMEJF <= 1)
                {
                    float num11 = (HKJOAJOKOIJ.GMCCPOAIBHC - HKJOAJOKOIJ.OLGCBGHOKDA) / (float)(Screen.width / 2);
                    float num12 = (HKJOAJOKOIJ.MINFPCEENFN - HKJOAJOKOIJ.NAHLPJKCPAO) / (float)(Screen.height / 2);
                    if (CameraClassCopy.BPJFLJPKKJK == 5)
                    {
                        CameraClassCopy.IFPJBJLEEDB = num11 * 9f;
                    }
                    else
                    {
                        CameraClassCopy.IFPJBJLEEDB = -(num11 * 9f);
                    }
                    CameraClassCopy.LHBKHGBDPLH = -(num12 * 3f);
                    CameraClassCopy.GIBHLNFEPKE = 1f;
                }
            }
            if (CameraClassCopy.BPJFLJPKKJK == 0 || CameraClassCopy.GIBHLNFEPKE > 0f)
            {
                CameraClassCopy.MOIMCJOBJME = CameraClassCopy.NJDGEELLAKG;
                CameraClassCopy.HLMAFBJHCIK = CameraClassCopy.FNNBCDPJBIO;
                CameraClassCopy.CEKNDFGOILP = CameraClassCopy.BMFDFFLPBOJ;
                CameraClassCopy.MOIMCJOBJME += NAEEIFNFBBO.PDOBPEFCMCK(CameraClassCopy.AAPMLHAGBGF + 90f, CameraClassCopy.IFPJBJLEEDB);
                CameraClassCopy.CEKNDFGOILP += NAEEIFNFBBO.GPMMBFPCFFL(CameraClassCopy.AAPMLHAGBGF + 90f, CameraClassCopy.IFPJBJLEEDB);
                if (NAEEIFNFBBO.FHPCDHIGILG(CameraClassCopy.NJDGEELLAKG, CameraClassCopy.BMFDFFLPBOJ, CameraClassCopy.KJOEMPCDGGD, CameraClassCopy.JOEOOOKAFDD) > 6f || CameraClassCopy.KHKIEPDJELK <= 0f)
                {
                    CameraClassCopy.MOIMCJOBJME += NAEEIFNFBBO.PDOBPEFCMCK(CameraClassCopy.AAPMLHAGBGF, CameraClassCopy.KHKIEPDJELK);
                    CameraClassCopy.CEKNDFGOILP += NAEEIFNFBBO.GPMMBFPCFFL(CameraClassCopy.AAPMLHAGBGF, CameraClassCopy.KHKIEPDJELK);
                    CameraClassCopy.HLMAFBJHCIK += CameraClassCopy.LHBKHGBDPLH;
                }
            }
            CameraClassCopy.IFPJBJLEEDB = 0f;
            CameraClassCopy.KHKIEPDJELK = 0f;
            CameraClassCopy.LHBKHGBDPLH = 0f;
            if (LIPNHOMGGHF.FAKHAFKOBPB >= 0 && CameraClassCopy.BPJFLJPKKJK != 6)
            {
                CameraClassCopy.JLPLEOBKPCD();
            }
            CameraClassCopy.EODCNMAEOGE = Mathf.MoveTowards(CameraClassCopy.EODCNMAEOGE, 1f, 0.01f * MBLIOKEDHHB.MCJHGEHEPMD);
            if (CameraClassCopy.BPJFLJPKKJK == 5)
            {
                CameraClassCopy.GDIHABOEHCD /= (CameraClassCopy.FNNBCDPJBIO - CameraClassCopy.GJGODIJIOKG) / 10f;
            }
            else
            {
                CameraClassCopy.GDIHABOEHCD /= CameraClassCopy.JHGPIHNAADD + CameraClassCopy.AMMOCBAOABP;
            }
            if (CameraClassCopy.BPJFLJPKKJK >= 3 && CameraClassCopy.BPJFLJPKKJK <= 4)
            {
                float num13 = NAEEIFNFBBO.OOALBELFICL(CameraClassCopy.GAEDKFPPAHF, NAEEIFNFBBO.IBHAGKMAKLE(CameraClassCopy.NJDGEELLAKG, CameraClassCopy.BMFDFFLPBOJ, CameraClassCopy.MOIMCJOBJME, CameraClassCopy.CEKNDFGOILP));
                if (num13 < 90f)
                {
                    CameraClassCopy.GDIHABOEHCD *= 4f;
                    Debug.Log("Speeding up camera because of angle difference=" + num13.ToString());
                }
            }
            CameraClassCopy.GDIHABOEHCD *= MBLIOKEDHHB.MCJHGEHEPMD;
            CameraClassCopy.GDIHABOEHCD *= CameraClassCopy.EODCNMAEOGE;
            if (CameraClassCopy.BPJFLJPKKJK == 6)
            {
                CameraClassCopy.GDIHABOEHCD = 1f;
            }
            if (CameraClassCopy.GDIHABOEHCD > 1f)
            {
                CameraClassCopy.GDIHABOEHCD = 1f;
            }
            if (JNCFFGOIJMF > 0 || CameraClassCopy.GIBHLNFEPKE > 0f)
            {
                CameraClassCopy.GDIHABOEHCD = 1f;
            }
            CameraClassCopy.NJDGEELLAKG = Mathf.Lerp(CameraClassCopy.NJDGEELLAKG, CameraClassCopy.MOIMCJOBJME, CameraClassCopy.GDIHABOEHCD);
            CameraClassCopy.FNNBCDPJBIO = Mathf.Lerp(CameraClassCopy.FNNBCDPJBIO, CameraClassCopy.HLMAFBJHCIK, CameraClassCopy.GDIHABOEHCD);
            CameraClassCopy.BMFDFFLPBOJ = Mathf.Lerp(CameraClassCopy.BMFDFFLPBOJ, CameraClassCopy.CEKNDFGOILP, CameraClassCopy.GDIHABOEHCD);
            if (World.location > 1 && World.location != 18 && CameraClassCopy.BPJFLJPKKJK != 6)
            {
                Vector3 vector2 = GIMNNPMAKNJ.BBFGCHIHEOK(CameraClassCopy.IGJHLDNPBPL, CameraClassCopy.DOEBJOGHIFL, CameraClassCopy.IJPOGOBJCGN, CameraClassCopy.NJDGEELLAKG, CameraClassCopy.FNNBCDPJBIO, CameraClassCopy.BMFDFFLPBOJ, 0f, 0, 1f);
                if (vector2.x != CameraClassCopy.NJDGEELLAKG || vector2.z != CameraClassCopy.BMFDFFLPBOJ)
                {
                    CameraClassCopy.NJDGEELLAKG = vector2.x;
                    CameraClassCopy.BMFDFFLPBOJ = vector2.z;
                    CameraClassCopy.EODCNMAEOGE = Mathf.MoveTowards(CameraClassCopy.EODCNMAEOGE, 0.5f, 0.02f * MBLIOKEDHHB.MCJHGEHEPMD);
                }
            }
            if (World.location == 11 || World.location == 15 || World.location == 39 || (FFCEGMEAIBP.LOBDMDPMFLK == 0 && NJBJIIIACEP.OAAMGFLINOB[NJBJIIIACEP.MLLALIOOPEP].LLGHFGNMCGF < 0f))
            {
                if (NAEEIFNFBBO.PMEEFNOLAGF(0, 5, 0) == 0)
                {
                    CameraClassCopy.EJHBJEAKPNC = UnityEngine.Random.Range(-1f, 1f);
                }
                CameraClassCopy.DOHDAOMCCFA = Mathf.Lerp(CameraClassCopy.DOHDAOMCCFA, CameraClassCopy.EJHBJEAKPNC * CHLPMKEGJBJ.FHELCLOILNB, 0.05f * MBLIOKEDHHB.MCJHGEHEPMD);
            }
            if (CameraClassCopy.BPJFLJPKKJK == 6 && CameraClassCopy.NNMDEFLLNBF > 0)
            {
                DFOGOCNBECG dfogocnbecg = NJBJIIIACEP.OAAMGFLINOB[CameraClassCopy.NNMDEFLLNBF];
                if (dfogocnbecg.AHBNKMMMGFI > 0f && dfogocnbecg.PCNHIIPBNEK[3] != null)
                {
                    if (CameraClassCopy.BPBKHCABOMM < 0.25f * MBLIOKEDHHB.MCJHGEHEPMD)
                    {
                        CameraClassCopy.BPBKHCABOMM = 0.25f * MBLIOKEDHHB.MCJHGEHEPMD;
                    }
                    CameraClassCopy.BHKGKKLDDBC.transform.position = dfogocnbecg.PCNHIIPBNEK[3].transform.position;
                    if (dfogocnbecg.OEGJEBDBGJA.shape[28] == 40 || dfogocnbecg.OEGJEBDBGJA.shape[31] == 40)
                    {
                        CameraClassCopy.BHKGKKLDDBC.transform.position += new Vector3(0f, 0.75f, 0f);
                    }
                    if (LIPNHOMGGHF.CMOMBJMMOBK >= 0f && LIPNHOMGGHF.CMOMBJMMOBK <= 1f)
                    {
                        CameraClassCopy.BHKGKKLDDBC.transform.eulerAngles = new Vector3(0f, dfogocnbecg.MPFFANIIEDG, 0f);
                        CameraClassCopy.BPBKHCABOMM = 1f;
                    }
                    else
                    {
                        Quaternion quaternion = dfogocnbecg.PCNHIIPBNEK[3].transform.rotation * Quaternion.Euler(-90f, 0f, 180f);
                        CameraClassCopy.BHKGKKLDDBC.transform.rotation = Quaternion.Lerp(CameraClassCopy.BHKGKKLDDBC.transform.rotation, quaternion, CameraClassCopy.BPBKHCABOMM);
                    }
                    CameraClassCopy.AAPMLHAGBGF = dfogocnbecg.MPFFANIIEDG;
                    CameraClassCopy.NJDGEELLAKG = CameraClassCopy.BHKGKKLDDBC.transform.position.x;
                    CameraClassCopy.FNNBCDPJBIO = CameraClassCopy.BHKGKKLDDBC.transform.position.y;
                    CameraClassCopy.BMFDFFLPBOJ = CameraClassCopy.BHKGKKLDDBC.transform.position.z;
                    CameraClassCopy.KJOEMPCDGGD = CameraClassCopy.NJDGEELLAKG;
                    CameraClassCopy.GJGODIJIOKG = CameraClassCopy.FNNBCDPJBIO;
                    CameraClassCopy.JOEOOOKAFDD = CameraClassCopy.BMFDFFLPBOJ;
                    return;
                }
            }
            else
            {
                CameraClassCopy.BHKGKKLDDBC.transform.position = new Vector3(CameraClassCopy.NJDGEELLAKG, CameraClassCopy.FNNBCDPJBIO + CameraClassCopy.DOHDAOMCCFA, CameraClassCopy.BMFDFFLPBOJ);
                CameraClassCopy.KGKBPODKJKL.transform.position = new Vector3(CameraClassCopy.KJOEMPCDGGD, CameraClassCopy.GJGODIJIOKG - CameraClassCopy.DOHDAOMCCFA, CameraClassCopy.JOEOOOKAFDD);
                if (CameraClassCopy.BPJFLJPKKJK == 5)
                {
                    if (World.location == 2 && (CameraClassCopy.JOEOOOKAFDD < World.camSouth || CameraClassCopy.JOEOOOKAFDD > World.camNorth || CameraClassCopy.KJOEMPCDGGD < World.camWest || CameraClassCopy.KJOEMPCDGGD > World.camEast))
                    {
                        CameraClassCopy.BHKGKKLDDBC.transform.LookAt(CameraClassCopy.KGKBPODKJKL.transform);
                        CameraClassCopy.AAPMLHAGBGF = CameraClassCopy.BHKGKKLDDBC.transform.eulerAngles.y;
                    }
                    else
                    {
                        CameraClassCopy.BHKGKKLDDBC.transform.eulerAngles = new Vector3(Mathf.LerpAngle(CameraClassCopy.BHKGKKLDDBC.transform.eulerAngles.x, 90f, CameraClassCopy.BPBKHCABOMM), Mathf.LerpAngle(CameraClassCopy.BHKGKKLDDBC.transform.eulerAngles.y, 0f, CameraClassCopy.BPBKHCABOMM), Mathf.LerpAngle(CameraClassCopy.BHKGKKLDDBC.transform.eulerAngles.z, 0f, CameraClassCopy.BPBKHCABOMM));
                        CameraClassCopy.AAPMLHAGBGF = 0f;
                    }
                }
                else
                {
                    CameraClassCopy.BHKGKKLDDBC.transform.LookAt(CameraClassCopy.KGKBPODKJKL.transform);
                    CameraClassCopy.AAPMLHAGBGF = CameraClassCopy.BHKGKKLDDBC.transform.eulerAngles.y;
                }
                if (CameraClassCopy.DOHDAOMCCFA != 0f)
                {
                    CameraClassCopy.BHKGKKLDDBC.transform.eulerAngles += new Vector3(0f, 0f, CameraClassCopy.DOHDAOMCCFA * 2f);
                }
            }
        }

        // Token: 0x0600000D RID: 13 RVA: 0x00005FBC File Offset: 0x000041BC
        public static void OPLJCOFMGNO(float HABMNGPDKJA)
        {
            if (LIPNHOMGGHF.FAKHAFKOBPB == 50)
            {
                PostProcessVolume component = CameraClassCopy.BHKGKKLDDBC.GetComponent<PostProcessVolume>();
                if (component != null)
                {
                    if (Mathf.Abs(HABMNGPDKJA) >= 5f)
                    {
                        component.enabled = true;
                        component.profile.GetSetting<ColorGrading>().saturation.Override(HABMNGPDKJA);
                        return;
                    }
                    component.enabled = false;
                }
            }
        }

        // Token: 0x0600000E RID: 14 RVA: 0x00006018 File Offset: 0x00004218
        public static void KHGDEBJPJON(float KPOFOJOJGDF, float AIEOAPKICPM, float IHEDIODNPFI, float HALIOKJGKDO)
        {
            float num = Mathf.Max(KPOFOJOJGDF, AIEOAPKICPM);
            float num2 = Mathf.Max(IHEDIODNPFI, HALIOKJGKDO);
            float num3 = num2 - num;
            if (num3 > 0f)
            {
                CameraClassCopy.KHKIEPDJELK = num2 / num / 6f;
                CameraClassCopy.GIBHLNFEPKE = 1f;
            }
            if (num3 < 0f)
            {
                CameraClassCopy.KHKIEPDJELK = -(num / num2 / 2f);
                CameraClassCopy.GIBHLNFEPKE = 1f;
            }
        }

        // Token: 0x0600000F RID: 15 RVA: 0x00006078 File Offset: 0x00004278
        public static void PGJOAKANLCN(int GOOKPABIPBC, int BDHHBIIKMLP = 2, int FKEMEFPKBBL = 1, float JNLAJNFCDHA = 0.75f)
        {
            if (GOOKPABIPBC > 0 && CameraClassCopy.EJAPALGEFCL != null && CameraClassCopy.PFIJGMNAIAE != null && !CameraClassCopy.EJAPALGEFCL.activeSelf && Characters.c[GOOKPABIPBC].scar[3] >= 0)
            {
                CameraClassCopy.EJAPALGEFCL.SetActive(true);
                CameraClassCopy.PFIJGMNAIAE.SetActive(true);
                GameObject gameObject = CameraClassCopy.EJAPALGEFCL.transform.Find("Photo BG").gameObject;
                float num = NAEEIFNFBBO.IADPBBEPJKF * JNLAJNFCDHA;
                float num2 = NAEEIFNFBBO.IADPBBEPJKF * JNLAJNFCDHA;
                if (FKEMEFPKBBL == 1 || FKEMEFPKBBL == 2)
                {
                    gameObject.transform.localScale = new Vector3(-num, num2, 1f);
                }
                else
                {
                    gameObject.transform.localScale = new Vector3(num, num2, 1f);
                }
                float num3 = 500f * num / 2f * 0.95f;
                if (FKEMEFPKBBL == 1 || FKEMEFPKBBL == 2)
                {
                    num3 = NAEEIFNFBBO.NLOEGFPCGJG - num3;
                }
                float num4 = 600f * num2 / 2f * 0.8f;
                if (FKEMEFPKBBL == 1 || FKEMEFPKBBL == 4)
                {
                    num4 = NAEEIFNFBBO.GLPIKFJPFEJ - 600f * num2 / 2f * 0.94f;
                }
                num3 -= NAEEIFNFBBO.NLOEGFPCGJG / 2f;
                num4 -= NAEEIFNFBBO.GLPIKFJPFEJ / 2f;
                gameObject.transform.localPosition = new Vector3(num3, num4, 750f * NAEEIFNFBBO.IADPBBEPJKF);
                MCDCDEBALPI.BBLJCJMDDLO(gameObject, RenderSettings.ambientLight.r, RenderSettings.ambientLight.g, RenderSettings.ambientLight.b);
                GameObject gameObject2 = CameraClassCopy.EJAPALGEFCL.transform.Find("Photo Overlay").gameObject;
                gameObject2.transform.localScale = gameObject.transform.localScale;
                gameObject2.transform.localPosition = new Vector3(num3, num4, -500f * NAEEIFNFBBO.IADPBBEPJKF);
                DFOGOCNBECG dfogocnbecg = NJBJIIIACEP.OAAMGFLINOB[0];
                dfogocnbecg.GOOKPABIPBC = GOOKPABIPBC;
                dfogocnbecg.EMDMDLNJFKP = Characters.c[dfogocnbecg.GOOKPABIPBC];
                BDHHBIIKMLP = dfogocnbecg.EMDMDLNJFKP.DKFABGIMCDB(dfogocnbecg.EMDMDLNJFKP.role);
                dfogocnbecg.OEGJEBDBGJA = dfogocnbecg.EMDMDLNJFKP.costume[BDHHBIIKMLP];
                if (dfogocnbecg.PCNHIIPBNEK[0] != null)
                {
                    UnityEngine.Object.Destroy(dfogocnbecg.PCNHIIPBNEK[0]);
                }
                dfogocnbecg.DDKAGOBJGBC(0);
                dfogocnbecg.ABHDOPBDDPB();
                dfogocnbecg.PCNHIIPBNEK[0].transform.SetParent(CameraClassCopy.EJAPALGEFCL.transform, false);
                if (FKEMEFPKBBL == 1 || FKEMEFPKBBL == 2)
                {
                    dfogocnbecg.MPFFANIIEDG = 190f;
                }
                else
                {
                    dfogocnbecg.MPFFANIIEDG = 170f;
                }
                dfogocnbecg.PCNHIIPBNEK[0].transform.eulerAngles = new Vector3(0f, dfogocnbecg.MPFFANIIEDG, 0f);
                num3 = (640f - 190f * JNLAJNFCDHA) * NAEEIFNFBBO.IADPBBEPJKF;
                num4 = 575f * NAEEIFNFBBO.JHECHHGBFEK * NAEEIFNFBBO.IADPBBEPJKF;
                if (JNLAJNFCDHA == 0.75f)
                {
                    num4 = 340f * NAEEIFNFBBO.JHECHHGBFEK * NAEEIFNFBBO.IADPBBEPJKF;
                }
                if (JNLAJNFCDHA == 0.5f)
                {
                    num4 = 75f * NAEEIFNFBBO.JHECHHGBFEK * NAEEIFNFBBO.IADPBBEPJKF;
                }
                if (FKEMEFPKBBL == 1)
                {
                    dfogocnbecg.PCNHIIPBNEK[0].transform.localPosition = new Vector3(num3, -num4, 0f);
                }
                if (FKEMEFPKBBL == 4)
                {
                    dfogocnbecg.PCNHIIPBNEK[0].transform.localPosition = new Vector3(-num3, -num4, 0f);
                }
                num4 = 900f * NAEEIFNFBBO.IADPBBEPJKF;
                if (JNLAJNFCDHA == 0.75f)
                {
                    num4 = 700f * NAEEIFNFBBO.IADPBBEPJKF;
                }
                if (JNLAJNFCDHA == 0.5f)
                {
                    num4 = 500f * NAEEIFNFBBO.IADPBBEPJKF;
                }
                num4 *= (NAEEIFNFBBO.DOFPCPKMACA + 1f) / 2f;
                if (FKEMEFPKBBL == 2)
                {
                    dfogocnbecg.PCNHIIPBNEK[0].transform.localPosition = new Vector3(num3, -num4, 0f);
                }
                if (FKEMEFPKBBL == 3)
                {
                    dfogocnbecg.PCNHIIPBNEK[0].transform.localPosition = new Vector3(-num3, -num4, 0f);
                }
                dfogocnbecg.JNLAJNFCDHA = 55f * (NAEEIFNFBBO.IADPBBEPJKF * JNLAJNFCDHA);
                dfogocnbecg.PCNHIIPBNEK[0].transform.localScale = new Vector3(dfogocnbecg.JNLAJNFCDHA, dfogocnbecg.JNLAJNFCDHA, dfogocnbecg.JNLAJNFCDHA);
                int num6;
                int num7;
                int num8;
                do
                {
                    int num5 = NAEEIFNFBBO.OMOADEKHHHO(MBLIOKEDHHB.AKICIDBAGOC, 0);
                    num6 = MBLIOKEDHHB.LHFJJPOPIAA[num5].PFDGHMKKHOF;
                    num7 = MBLIOKEDHHB.LHFJJPOPIAA[num5].EJPKJOFMIAI[NAEEIFNFBBO.PMEEFNOLAGF(0, MBLIOKEDHHB.LHFJJPOPIAA[num5].EJPKJOFMIAI.Length - 1, 0)];
                    if (NAEEIFNFBBO.PMEEFNOLAGF(0, 3, 0) == 0)
                    {
                        num6 = 0;
                        num7 = NAEEIFNFBBO.PMEEFNOLAGF(3, 24, 0);
                    }
                    if (dfogocnbecg.EMDMDLNJFKP.gender > 0 && NAEEIFNFBBO.PMEEFNOLAGF(0, 1, 0) == 0)
                    {
                        num6 = 0;
                        num7 = NAEEIFNFBBO.PMEEFNOLAGF(82, 83, 0);
                    }
                    if (dfogocnbecg.EMDMDLNJFKP.injury != 0 && NAEEIFNFBBO.PMEEFNOLAGF(0, 1, 0) == 0)
                    {
                        num6 = 4;
                        num7 = NAEEIFNFBBO.PMEEFNOLAGF(1, 6, 0);
                    }
                    num8 = 1;
                    if (num6 == 3 && (num7 == 36 || num7 == 37 || num7 == 42))
                    {
                        num8 = 0;
                    }
                    if (num6 == 4 && num7 == 39)
                    {
                        num8 = 0;
                    }
                }
                while (num8 == 0);
                dfogocnbecg.FJHHJGONAFO(num6, (float)num7);
                dfogocnbecg.KOLHFFPPCEE(dfogocnbecg.EMDMDLNJFKP.demeanour * 50f);
                foreach (Transform transform in dfogocnbecg.PCNHIIPBNEK[0].GetComponentsInChildren<Transform>())
                {
                    if (transform.gameObject.name != "Hips")
                    {
                        transform.gameObject.layer = LayerMask.NameToLayer("UI");
                    }
                }
                for (int j = 4; j <= 15; j++)
                {
                    if ((j >= 4 && j <= 7) || (j >= 14 && j <= 15))
                    {
                        dfogocnbecg.PCNHIIPBNEK[j].SetActive(false);
                    }
                }
            }
        }

        // Token: 0x06000010 RID: 16 RVA: 0x0000664C File Offset: 0x0000484C
        public static bool FIJILHEFHIK(float MMBJPONJJGM, float EJOKLBHLEEJ)
        {
            bool flag = true;
            if (LIPNHOMGGHF.FAKHAFKOBPB == 29)
            {
                if (EJOKLBHLEEJ < (float)Screen.height * 0.1f || EJOKLBHLEEJ > (float)Screen.height * 0.9f)
                {
                    flag = false;
                }
                if (MMBJPONJJGM < (float)Screen.width * 0.1f || MMBJPONJJGM > (float)Screen.width * 0.9f)
                {
                    flag = false;
                }
            }
            else
            {
                if (EJOKLBHLEEJ < (float)Screen.height * 0.2f || EJOKLBHLEEJ > (float)Screen.height * 0.8f)
                {
                    flag = false;
                }
                if (MMBJPONJJGM < (float)Screen.width * 0.2f || MMBJPONJJGM > (float)Screen.width * 0.8f)
                {
                    flag = false;
                }
            }
            if (LIPNHOMGGHF.FAKHAFKOBPB == 50 && NAEEIFNFBBO.BDLIKACHFDK >= 2 && EJOKLBHLEEJ < (float)Screen.height * (0.45f * HKJOAJOKOIJ.NFHOMHPHMBP) && HKJOAJOKOIJ.BAOIFCAIKGP[0] != null && HKJOAJOKOIJ.MLGNDKBMHHP[0] != null)
            {
                if (HKJOAJOKOIJ.BAOIFCAIKGP[0].activeSelf && MMBJPONJJGM < (float)Screen.width * (0.4f * HKJOAJOKOIJ.NFHOMHPHMBP))
                {
                    flag = false;
                }
                if (HKJOAJOKOIJ.MLGNDKBMHHP[0].activeSelf && MMBJPONJJGM > (float)Screen.width * (0.55f * HKJOAJOKOIJ.NFHOMHPHMBP))
                {
                    flag = false;
                }
            }
            return flag;
        }

        // Token: 0x06000011 RID: 17 RVA: 0x00006778 File Offset: 0x00004978
        public static Vector3 OOAMFDCLFMG(Vector3 IJIAKGAJJAE, Vector3 NKPHKLBPAGF, Vector3 COONEHGPNGG, Vector3 MLBBODNCOOB, Vector3 DABLFMBMHLL)
        {
            Vector3 vector = IJIAKGAJJAE;
            float num = 9999f;
            float num2 = Vector3.Distance(IJIAKGAJJAE, NKPHKLBPAGF);
            if (num2 < num)
            {
                num = num2;
                vector = NKPHKLBPAGF;
            }
            num2 = Vector3.Distance(IJIAKGAJJAE, COONEHGPNGG);
            if (num2 < num)
            {
                num = num2;
                vector = COONEHGPNGG;
            }
            num2 = Vector3.Distance(IJIAKGAJJAE, MLBBODNCOOB);
            if (num2 < num)
            {
                num = num2;
                vector = MLBBODNCOOB;
            }
            num2 = Vector3.Distance(IJIAKGAJJAE, DABLFMBMHLL);
            if (num2 < num)
            {
                vector = DABLFMBMHLL;
            }
            return vector;
        }

        // Token: 0x06000012 RID: 18 RVA: 0x000067D8 File Offset: 0x000049D8
        public static float EHNKMGPGIBO()
        {
            float num = 0f;
            if (World.location == 2)
            {
                num = 100f;
            }
            if (World.location == 22)
            {
                num = 100f;
            }
            if (World.location == 30)
            {
                num = 40f;
            }
            if (num == 0f)
            {
                num = Mathf.Min(World.camNorth - World.camSouth, World.camEast - World.camWest);
                num *= 0.75f;
            }
            if (num < 40f)
            {
                num = 40f;
            }
            if (num > 100f)
            {
                num = 100f;
            }
            return num;
        }

        // Token: 0x06000013 RID: 19 RVA: 0x00006860 File Offset: 0x00004A60
        public static void HJPNCDFFLLI()
        {
            if (CameraClassCopy.EJAPALGEFCL != null)
            {
                CameraClassCopy.EJAPALGEFCL.SetActive(false);
            }
            if (CameraClassCopy.PFIJGMNAIAE != null)
            {
                CameraClassCopy.PFIJGMNAIAE.SetActive(false);
            }
            if (NJBJIIIACEP.OAAMGFLINOB[0].PCNHIIPBNEK[0] != null)
            {
                UnityEngine.Object.Destroy(NJBJIIIACEP.OAAMGFLINOB[0].PCNHIIPBNEK[0]);
            }
        }

        // Token: 0x06000014 RID: 20 RVA: 0x000068C8 File Offset: 0x00004AC8
        public static float HEJMJEKNCND(float COBPODAOBFG, float JKKHKFIELBP, float DDEDKGKFOMG = -1f, float OCIDDIPCGED = -1f)
        {
            float num = 9999f;
            float num2 = 0f;
            float num3 = CameraClassCopy.KGKBPODKJKL.transform.position.x + NAEEIFNFBBO.PDOBPEFCMCK(COBPODAOBFG, CameraClassCopy.OGCNMOGKCPE);
            float num4 = CameraClassCopy.KGKBPODKJKL.transform.position.z + NAEEIFNFBBO.GPMMBFPCFFL(COBPODAOBFG, CameraClassCopy.OGCNMOGKCPE);
            float num5 = NAEEIFNFBBO.FHPCDHIGILG(num3, num4, CameraClassCopy.BHKGKKLDDBC.transform.position.x, CameraClassCopy.BHKGKKLDDBC.transform.position.z);
            if (num5 < num)
            {
                num = num5;
                num2 = COBPODAOBFG;
            }
            float num6 = CameraClassCopy.KGKBPODKJKL.transform.position.x + NAEEIFNFBBO.PDOBPEFCMCK(JKKHKFIELBP, CameraClassCopy.OGCNMOGKCPE);
            num4 = CameraClassCopy.KGKBPODKJKL.transform.position.z + NAEEIFNFBBO.GPMMBFPCFFL(JKKHKFIELBP, CameraClassCopy.OGCNMOGKCPE);
            float num7 = NAEEIFNFBBO.FHPCDHIGILG(num6, num4, CameraClassCopy.BHKGKKLDDBC.transform.position.x, CameraClassCopy.BHKGKKLDDBC.transform.position.z);
            if (num7 < num)
            {
                num = num7;
                num2 = JKKHKFIELBP;
            }
            if (DDEDKGKFOMG >= 0f)
            {
                float num8 = CameraClassCopy.KGKBPODKJKL.transform.position.x + NAEEIFNFBBO.PDOBPEFCMCK(DDEDKGKFOMG, CameraClassCopy.OGCNMOGKCPE);
                num4 = CameraClassCopy.KGKBPODKJKL.transform.position.z + NAEEIFNFBBO.GPMMBFPCFFL(DDEDKGKFOMG, CameraClassCopy.OGCNMOGKCPE);
                float num9 = NAEEIFNFBBO.FHPCDHIGILG(num8, num4, CameraClassCopy.BHKGKKLDDBC.transform.position.x, CameraClassCopy.BHKGKKLDDBC.transform.position.z);
                if (num9 < num)
                {
                    num = num9;
                    num2 = DDEDKGKFOMG;
                }
            }
            if (OCIDDIPCGED >= 0f)
            {
                float num10 = CameraClassCopy.KGKBPODKJKL.transform.position.x + NAEEIFNFBBO.PDOBPEFCMCK(OCIDDIPCGED, CameraClassCopy.OGCNMOGKCPE);
                num4 = CameraClassCopy.KGKBPODKJKL.transform.position.z + NAEEIFNFBBO.GPMMBFPCFFL(OCIDDIPCGED, CameraClassCopy.OGCNMOGKCPE);
                float num11 = NAEEIFNFBBO.FHPCDHIGILG(num10, num4, CameraClassCopy.BHKGKKLDDBC.transform.position.x, CameraClassCopy.BHKGKKLDDBC.transform.position.z);
                if (num11 < num)
                {
                    num2 = OCIDDIPCGED;
                }
            }
            return num2;
        }

        // Token: 0x06000015 RID: 21 RVA: 0x00006B04 File Offset: 0x00004D04
        public static void ICGNAJFLAHL()
        {
            CameraClassCopy.BHKGKKLDDBC = Plugin.SecondCamera;
            Vector3 vector = NJBJIIIACEP.MGGKCJIBJLC(0, 1);
            if (LIPNHOMGGHF.FAKHAFKOBPB == 50 && FFCEGMEAIBP.LOBDMDPMFLK == 0)
            {
                Character character = Characters.c[Plugin.SecondPlayer];
                CameraClassCopy.ONOKPJKPEFL = CameraClassCopy.BEMIDHDBAPB;
                CameraClassCopy.GMJKGKDFHOH = CameraClassCopy.MLEFLJDMHJL;
                CameraClassCopy.JBFIOOFDMND = character.x;
                CameraClassCopy.IKLMALGHGFI = character.y + 15f;
                CameraClassCopy.CMHIKHJGAGD = character.z;
                CameraClassCopy.NJDGEELLAKG = 0f;
                CameraClassCopy.FNNBCDPJBIO = World.ground + 15f;
                CameraClassCopy.BMFDFFLPBOJ = 0f;
                if (World.location == 9 && character.z > 50f)
                {
                    CameraClassCopy.BMFDFFLPBOJ = 82f;
                }
                if (World.location == 20 && NEGAFEHECNL.DLCPIINMIDD > 0)
                {
                    CameraClassCopy.BMFDFFLPBOJ = World.farSouth;
                }
                if (World.location == 27 && NEGAFEHECNL.DLCPIINMIDD > 0)
                {
                    CameraClassCopy.NJDGEELLAKG = UnityEngine.Random.Range(-20f, 20f);
                    CameraClassCopy.BMFDFFLPBOJ = (float)NAEEIFNFBBO.CFPJBJFFJFH((int)World.farSouth, 0);
                    CameraClassCopy.FNNBCDPJBIO += 5f;
                }
                if (World.location == 28 && character.z > 71f)
                {
                    CameraClassCopy.BMFDFFLPBOJ = 100f;
                }
                if (World.location == 29)
                {
                    CameraClassCopy.NJDGEELLAKG = -25f;
                    CameraClassCopy.BMFDFFLPBOJ = 25f;
                }
                if (GIMNNPMAKNJ.DGINJFACEDM == 1)
                {
                    if (character.z > -35f && character.y < 30f)
                    {
                        CameraClassCopy.BMFDFFLPBOJ = -65f;
                    }
                    if (character.z > -20f)
                    {
                        if (character.x <= -23.5f)
                        {
                            CameraClassCopy.NJDGEELLAKG = -35f;
                        }
                        if (character.x >= 22f)
                        {
                            CameraClassCopy.NJDGEELLAKG = 35f;
                        }
                    }
                }
                if (World.location == 46 && character.z > 90f)
                {
                    CameraClassCopy.BMFDFFLPBOJ = 145f;
                }
                if (World.location == 48)
                {
                    CameraClassCopy.BMFDFFLPBOJ = 125f;
                }
                if (World.location == 30)
                {
                    if (character.x <= -45f)
                    {
                        CameraClassCopy.NJDGEELLAKG = -45f;
                    }
                    if (character.x >= 45f)
                    {
                        CameraClassCopy.NJDGEELLAKG = 45f;
                    }
                    if (character.z <= -45f)
                    {
                        CameraClassCopy.BMFDFFLPBOJ = -45f;
                    }
                    if (character.z >= 45f)
                    {
                        CameraClassCopy.BMFDFFLPBOJ = 45f;
                    }
                }
                if (CameraClassCopy.ONOKPJKPEFL == 5)
                {
                    CameraClassCopy.NJDGEELLAKG = character.x;
                    CameraClassCopy.BMFDFFLPBOJ = character.z;
                }
                if (CameraClassCopy.ONOKPJKPEFL == 7)
                {
                    CameraClassCopy.NJDGEELLAKG = character.x;
                    CameraClassCopy.BMFDFFLPBOJ = character.z;
                    if (World.location == 4 || World.location == 7 || World.location == 25 || (World.location >= 31 && World.location <= 36) || (World.location >= 50 && World.location <= 54))
                    {
                        CameraClassCopy.NJDGEELLAKG = -character.x;
                        CameraClassCopy.BMFDFFLPBOJ = -character.z;
                    }
                }
                CameraClassCopy.MOIMCJOBJME = CameraClassCopy.NJDGEELLAKG;
                CameraClassCopy.HLMAFBJHCIK = CameraClassCopy.FNNBCDPJBIO;
                CameraClassCopy.CEKNDFGOILP = CameraClassCopy.BMFDFFLPBOJ;
            }
            else
            {
                CameraClassCopy.ONOKPJKPEFL = CameraClassCopy.BKMPKCDDMLF;
                CameraClassCopy.GMJKGKDFHOH = CameraClassCopy.CJJEGOLMCMF;
                if (LIPNHOMGGHF.FAKHAFKOBPB == 50 && NAEEIFNFBBO.CBMHGKFFHJE == 1 && NAEEIFNFBBO.EPNLHPHFEOB > 0 && CameraClassCopy.BEMIDHDBAPB == 6)
                {
                    CameraClassCopy.ONOKPJKPEFL = CameraClassCopy.BEMIDHDBAPB;
                }
                if (World.arenaShape > 0)
                {
                    if (CameraClassCopy.ONOKPJKPEFL == 6)
                    {
                        CameraClassCopy.MOIMCJOBJME = 0f;
                        CameraClassCopy.CEKNDFGOILP = 145f;
                        CameraClassCopy.HLMAFBJHCIK = World.ground + 15f;
                    }
                    else
                    {
                        CameraClassCopy.MOIMCJOBJME = UnityEngine.Random.Range(-115f, 115f);
                        CameraClassCopy.CEKNDFGOILP = UnityEngine.Random.Range(115f, 115f) * (float)NAEEIFNFBBO.CFPJBJFFJFH(-1, 1);
                        if (NAEEIFNFBBO.PPOOFMKBBEB > 0 || FFCEGMEAIBP.OLJFOJOLLOM < 0 || NJBJIIIACEP.OAAMGFLINOB[NJBJIIIACEP.MLLALIOOPEP].AHBNKMMMGFI == 0f)
                        {
                            CameraClassCopy.MOIMCJOBJME = UnityEngine.Random.Range(-50f, 50f);
                            CameraClassCopy.CEKNDFGOILP = UnityEngine.Random.Range(-115f, -115f);
                        }
                        if (CameraClassCopy.ONOKPJKPEFL == 3)
                        {
                            CameraClassCopy.CEKNDFGOILP = -115f;
                        }
                        if (CameraClassCopy.ONOKPJKPEFL == 4)
                        {
                            CameraClassCopy.MOIMCJOBJME = -115f;
                            CameraClassCopy.CEKNDFGOILP = -115f;
                        }
                        if (CameraClassCopy.ONOKPJKPEFL == 5)
                        {
                            CameraClassCopy.MOIMCJOBJME = 0f;
                            CameraClassCopy.CEKNDFGOILP = 0f;
                        }
                        CameraClassCopy.HLMAFBJHCIK = UnityEngine.Random.Range(World.ringGround, 50f);
                    }
                }
                else
                {
                    int num = 0;
                    int num4;
                    do
                    {
                        Vector3 vector2 = World.DIHKHJLKFNC(World.location, 69);
                        CameraClassCopy.MOIMCJOBJME = vector2.x;
                        CameraClassCopy.CEKNDFGOILP = vector2.z;
                        if (World.location == 9)
                        {
                            CameraClassCopy.CEKNDFGOILP = UnityEngine.Random.Range(World.camSouth, 35f);
                        }
                        if (GIMNNPMAKNJ.DGINJFACEDM == 1)
                        {
                            CameraClassCopy.MOIMCJOBJME = UnityEngine.Random.Range(-55f, 53f);
                            CameraClassCopy.CEKNDFGOILP = UnityEngine.Random.Range(World.camSouth, 0f);
                        }
                        CameraClassCopy.HLMAFBJHCIK = UnityEngine.Random.Range(World.ground + 10f, World.ceiling);
                        if (LIPNHOMGGHF.FAKHAFKOBPB == 70 && World.location == 2 && NAEEIFNFBBO.PMEEFNOLAGF(0, 3, 0) > 0)
                        {
                            float num2 = Mathf.LerpAngle(NJBJIIIACEP.OAAMGFLINOB[1].MPFFANIIEDG, NJBJIIIACEP.OAAMGFLINOB[2].MPFFANIIEDG, 0.5f) + (float)NAEEIFNFBBO.PMEEFNOLAGF(-60, 60, 0);
                            float num3 = (float)UnityEngine.Random.Range(20, 50);
                            CameraClassCopy.MOIMCJOBJME = vector.x + NAEEIFNFBBO.PDOBPEFCMCK(num2, num3);
                            CameraClassCopy.CEKNDFGOILP = vector.z + NAEEIFNFBBO.GPMMBFPCFFL(num2, num3);
                        }
                        if (LIPNHOMGGHF.FAKHAFKOBPB == 70 && World.location == 21)
                        {
                            CameraClassCopy.CEKNDFGOILP = UnityEngine.Random.Range(World.camSouth, -25f);
                            CameraClassCopy.HLMAFBJHCIK = UnityEngine.Random.Range(15f, World.ceiling);
                        }
                        num++;
                        num4 = 1;
                        if (CameraClassCopy.MOIMCJOBJME < World.camWest || CameraClassCopy.MOIMCJOBJME > World.camEast)
                        {
                            num4 = 0;
                        }
                        if (CameraClassCopy.CEKNDFGOILP < World.camSouth || CameraClassCopy.CEKNDFGOILP > World.camNorth)
                        {
                            num4 = 0;
                        }
                        if (NAEEIFNFBBO.FHPCDHIGILG(CameraClassCopy.MOIMCJOBJME, CameraClassCopy.CEKNDFGOILP, vector.x, vector.z) > 50f && World.location != 30)
                        {
                            num4 = 0;
                            Debug.Log(num.ToString() + ". too far from centre");
                        }
                        if (NAEEIFNFBBO.FHPCDHIGILG(CameraClassCopy.MOIMCJOBJME, CameraClassCopy.CEKNDFGOILP, vector.x, vector.z) < 20f)
                        {
                            num4 = 0;
                            Debug.Log(num.ToString() + ". too close to centre");
                        }
                        if (num4 > 0)
                        {
                            for (int i = 1; i <= NJBJIIIACEP.NBBBLJDBLNM; i++)
                            {
                                if (NAEEIFNFBBO.FHPCDHIGILG(CameraClassCopy.MOIMCJOBJME, CameraClassCopy.CEKNDFGOILP, NJBJIIIACEP.OAAMGFLINOB[i].NJDGEELLAKG, NJBJIIIACEP.OAAMGFLINOB[i].BMFDFFLPBOJ) < 20f)
                                {
                                    num4 = 0;
                                    Debug.Log(num.ToString() + ". too close to P" + i.ToString());
                                }
                            }
                        }
                    }
                    while (num < 1000 && num4 == 0);
                    CameraClassCopy.JBFIOOFDMND = vector.x;
                    CameraClassCopy.IKLMALGHGFI = vector.y;
                    CameraClassCopy.CMHIKHJGAGD = vector.z;
                    if (NJBJIIIACEP.MLLALIOOPEP > 0)
                    {
                        CameraClassCopy.IKLMALGHGFI = NJBJIIIACEP.OAAMGFLINOB[NJBJIIIACEP.MLLALIOOPEP].FNNBCDPJBIO + 15f;
                    }
                }
            }
            if (LIPNHOMGGHF.FAKHAFKOBPB < 0)
            {
                CameraClassCopy.HLMAFBJHCIK = 5f;
                CameraClassCopy.HLMAFBJHCIK = 15f;
                CameraClassCopy.CEKNDFGOILP = 25f;
            }
            CameraClassCopy.KGKBPODKJKL = new GameObject();
            CameraClassCopy.KGKBPODKJKL.name = "Camera Focal Point";
            if ((World.ringShape > 0 || World.arenaShape > 0) && FFCEGMEAIBP.LOBDMDPMFLK != 0)
            {
                CameraClassCopy.JBFIOOFDMND = 0f;
                CameraClassCopy.IKLMALGHGFI = 20f;
                CameraClassCopy.CMHIKHJGAGD = 0f;
            }
            CameraClassCopy.KJOEMPCDGGD = CameraClassCopy.JBFIOOFDMND;
            CameraClassCopy.GJGODIJIOKG = CameraClassCopy.IKLMALGHGFI;
            CameraClassCopy.JOEOOOKAFDD = CameraClassCopy.CMHIKHJGAGD;
            CameraClassCopy.KGKBPODKJKL.transform.position = new Vector3(CameraClassCopy.KJOEMPCDGGD, CameraClassCopy.GJGODIJIOKG, CameraClassCopy.JOEOOOKAFDD);
            CameraClassCopy.NNMDEFLLNBF = 0;
            CameraClassCopy.JCKCCDKDEKP = 0;
            CameraClassCopy.NCCMNFNECKC = 0;
            CameraClassCopy.COMOHLEACFP = 0f;
            CameraClassCopy.DOHDAOMCCFA = 0f;
            CameraClassCopy.GIBHLNFEPKE = 0f;
            CameraClassCopy.EODCNMAEOGE = 1f;
            if (CameraClassCopy.BKLMPJIODMA > 1f)
            {
                CameraClassCopy.BKLMPJIODMA = 1f;
            }
            if (GIMNNPMAKNJ.DGINJFACEDM == 1)
            {
                if ((CameraClassCopy.CEKNDFGOILP > -20f || CameraClassCopy.IKLMALGHGFI > 30f) && CameraClassCopy.HLMAFBJHCIK < 36f)
                {
                    CameraClassCopy.HLMAFBJHCIK = World.ceiling;
                }
                if ((CameraClassCopy.MOIMCJOBJME <= -23.5f || CameraClassCopy.MOIMCJOBJME >= 22f) && CameraClassCopy.IKLMALGHGFI < 30f && CameraClassCopy.HLMAFBJHCIK > 15f)
                {
                    CameraClassCopy.HLMAFBJHCIK = 15f;
                }
            }
            if (CameraClassCopy.ONOKPJKPEFL != 6 && CameraClassCopy.PMELGMJHBPC != 6)
            {
                CameraClassCopy.JLPLEOBKPCD();
            }
            CameraClassCopy.NJDGEELLAKG = CameraClassCopy.MOIMCJOBJME;
            CameraClassCopy.FNNBCDPJBIO = CameraClassCopy.HLMAFBJHCIK;
            CameraClassCopy.BMFDFFLPBOJ = CameraClassCopy.CEKNDFGOILP;
            CameraClassCopy.BHKGKKLDDBC.transform.position = new Vector3(CameraClassCopy.NJDGEELLAKG, CameraClassCopy.FNNBCDPJBIO, CameraClassCopy.BMFDFFLPBOJ);
            CameraClassCopy.BHKGKKLDDBC.transform.LookAt(CameraClassCopy.KGKBPODKJKL.transform);
            if (LIPNHOMGGHF.FAKHAFKOBPB == 50)
            {
                if (CameraClassCopy.ONOKPJKPEFL == 5 || CameraClassCopy.ONOKPJKPEFL == 6 || CameraClassCopy.PMELGMJHBPC == 6 || CameraClassCopy.ONOKPJKPEFL == 7)
                {
                    CameraClassCopy.DIJBHIAAIOF(1);
                }
                else if (FFCEGMEAIBP.LOBDMDPMFLK == 0)
                {
                    CameraClassCopy.DIJBHIAAIOF(0);
                }
            }
            if (World.location == 18 || World.location == 22 || World.location == 46)
            {
                CameraClassCopy.BHKGKKLDDBC.farClipPlane = 1000f;
            }
            CameraClassCopy.OPLJCOFMGNO(CameraClassCopy.HJOKIDPBKJL);
        }

        // Token: 0x06000016 RID: 22 RVA: 0x00007484 File Offset: 0x00005684
        public static void OPNLNIADJIA(GameObject GMBNIJFILBA)
        {
            Quaternion rotation = Plugin.SecondCamera.transform.rotation;
            GMBNIJFILBA.transform.LookAt(GMBNIJFILBA.transform.position + rotation * Vector3.forward, rotation * Vector3.up);
        }

        // Token: 0x04000003 RID: 3
        public static Camera BHKGKKLDDBC;

        // Token: 0x04000004 RID: 4
        public static GameObject KGKBPODKJKL;

        // Token: 0x04000005 RID: 5
        public static float NJDGEELLAKG;

        // Token: 0x04000006 RID: 6
        public static float FNNBCDPJBIO;

        // Token: 0x04000007 RID: 7
        public static float BMFDFFLPBOJ;

        // Token: 0x04000008 RID: 8
        public static float MOIMCJOBJME;

        // Token: 0x04000009 RID: 9
        public static float HLMAFBJHCIK;

        // Token: 0x0400000A RID: 10
        public static float CEKNDFGOILP;

        // Token: 0x0400000B RID: 11
        public static float IGJHLDNPBPL;

        // Token: 0x0400000C RID: 12
        public static float DOEBJOGHIFL;

        // Token: 0x0400000D RID: 13
        public static float IJPOGOBJCGN;

        // Token: 0x0400000E RID: 14
        public static float KJOEMPCDGGD;

        // Token: 0x0400000F RID: 15
        public static float GJGODIJIOKG;

        // Token: 0x04000010 RID: 16
        public static float JOEOOOKAFDD;

        // Token: 0x04000011 RID: 17
        public static float JBFIOOFDMND;

        // Token: 0x04000012 RID: 18
        public static float IKLMALGHGFI;

        // Token: 0x04000013 RID: 19
        public static float CMHIKHJGAGD;

        // Token: 0x04000014 RID: 20
        public static float BPBKHCABOMM = 0.02f;

        // Token: 0x04000015 RID: 21
        public static float GDIHABOEHCD = 0.01f;

        // Token: 0x04000016 RID: 22
        public static float GCDFHFMNGID = 0.5f;

        // Token: 0x04000017 RID: 23
        public static float LCKFFGMJIKG = 0f;

        // Token: 0x04000018 RID: 24
        public static float EODCNMAEOGE = 1f;

        // Token: 0x04000019 RID: 25
        public static int JECOJHEMKFP = 7;

        // Token: 0x0400001A RID: 26
        public static int BPJFLJPKKJK = 1;

        // Token: 0x0400001B RID: 27
        public static int ONOKPJKPEFL = 1;

        // Token: 0x0400001C RID: 28
        public static int BKMPKCDDMLF = 1;

        // Token: 0x0400001D RID: 29
        public static int BEMIDHDBAPB = 1;

        // Token: 0x0400001E RID: 30
        public static int NNMDEFLLNBF = 0;

        // Token: 0x0400001F RID: 31
        public static int JCKCCDKDEKP = 0;

        // Token: 0x04000020 RID: 32
        public static int NCCMNFNECKC = 0;

        // Token: 0x04000021 RID: 33
        public static int PMELGMJHBPC = 0;

        // Token: 0x04000022 RID: 34
        public static float COMOHLEACFP = 0f;

        // Token: 0x04000023 RID: 35
        public static float LAMPIGLOGDP = 0f;

        // Token: 0x04000024 RID: 36
        public static int ODGCKCPJMJK;

        // Token: 0x04000025 RID: 37
        public static int GMJKGKDFHOH = 0;

        // Token: 0x04000026 RID: 38
        public static int CJJEGOLMCMF = 0;

        // Token: 0x04000027 RID: 39
        public static int MLEFLJDMHJL = -1;

        // Token: 0x04000028 RID: 40
        public static float OGCNMOGKCPE;

        // Token: 0x04000029 RID: 41
        public static float JHGPIHNAADD = 1.2f;

        // Token: 0x0400002A RID: 42
        public static float AMMOCBAOABP = 0.3f;

        // Token: 0x0400002B RID: 43
        public static float DCLAJILMLMK;

        // Token: 0x0400002C RID: 44
        public static float NLBDCNFGBDL;

        // Token: 0x0400002D RID: 45
        public static float GAEDKFPPAHF;

        // Token: 0x0400002E RID: 46
        public static float FKBDCLLANMK;

        // Token: 0x0400002F RID: 47
        public static float AAPMLHAGBGF;

        // Token: 0x04000030 RID: 48
        public static float GIBHLNFEPKE;

        // Token: 0x04000031 RID: 49
        public static float DOHDAOMCCFA;

        // Token: 0x04000032 RID: 50
        public static float EJHBJEAKPNC;

        // Token: 0x04000033 RID: 51
        public static float IFPJBJLEEDB;

        // Token: 0x04000034 RID: 52
        public static float LHBKHGBDPLH;

        // Token: 0x04000035 RID: 53
        public static float KHKIEPDJELK;

        // Token: 0x04000036 RID: 54
        public static float BKLMPJIODMA = 1f;

        // Token: 0x04000037 RID: 55
        public static float HJOKIDPBKJL = 0f;

        // Token: 0x04000038 RID: 56
        public static GameObject EJAPALGEFCL;

        // Token: 0x04000039 RID: 57
        public static GameObject PFIJGMNAIAE;
    }
}